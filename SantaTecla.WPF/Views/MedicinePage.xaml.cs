﻿using SantaTecla.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using SantaTecla.Models;
using SantaTecla.Services;

namespace SantaTecla.WPF.Views
{
    /// <summary>
    /// Lógica de interacción para MedicinePage.xaml
    /// </summary>
    public partial class MedicinePage : Page
    {
        
        public MedicinePage(int opc)
        {
            InitializeComponent();

            if (opc == 1)
                agregar.IsEnabled = false;
            if (opc == 2)
            {
                consultar.IsEnabled = false;
                labelA.Visibility =0;
                cantidad.Visibility = 0;
            }
            consultar.Click += Consultar_Click;
            agregar.Click += Agregar_Click;
        }



        private async void Agregar_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(referencia.Text))
            {
                int id = int.Parse(referencia.Text);
                Loading.Visibility = Visibility.Visible;
                SantaTeclaService service = new SantaTeclaService();
                var medicamento = await service.GetMedicamentosByNameOrId(id);

                medicamento.Cantidad = int.Parse(cantidad.Text);
                if (await service.PutMedicamento(id, medicamento))
                    MessageBox.Show("Medicamento Agregado");
                else
                    MessageBox.Show("Error al agregar");

            }
            else
                MessageBox.Show("Ingrese Referencia");

            Loading.Visibility = Visibility.Collapsed;

        }

        private async void Consultar_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(referencia.Text))
            {
                int id = int.Parse(referencia.Text);
                Loading.Visibility = Visibility.Visible;
                SantaTeclaService service = new SantaTeclaService();
                var medicamento = await service.GetMedicamentosByNameOrId(id);
                
                MessageBox.Show($"Disponible: {medicamento.Cantidad}");
            }
            else
                MessageBox.Show("Ingrese Referencia");
            Loading.Visibility = Visibility.Collapsed;
        }
    }
}
