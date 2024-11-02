using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDeEntidades;
using CapaDeNegocio;

namespace CapaDePresentacion
{
    public partial class formRegistroProductos : Form
    {
        private ProductoBL productoBL = new ProductoBL();

        public formRegistroProductos()
        {
            InitializeComponent();
            CargarDatos();

            // Asociar evento KeyPress para el campo Precio
            txtPrecio.KeyPress += new KeyPressEventHandler(txtPrecio_KeyPress);

            // Asociar evento KeyPress para el campo Cantidad
            txtCantidad.KeyPress += new KeyPressEventHandler(txtCantidad_KeyPress);
        }

        // Evento para permitir solo números y un punto decimal en Precio
        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo dígitos y un único punto decimal
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Permitir solo un punto decimal en el Precio
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        // Evento para permitir solo números en Cantidad
        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo dígitos
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            // Comprobar si algún campo está vacío
            if (string.IsNullOrWhiteSpace(txtId.Text) ||
                string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtDescripcion.Text) ||
                string.IsNullOrWhiteSpace(txtPrecio.Text))
            {
                // Mostrar mensaje de error y salir del método
                MessageBox.Show("Todos los campos deben estar llenos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Convertir el precio a decimal
            if (!decimal.TryParse(txtPrecio.Text, out decimal precio))
            {
                MessageBox.Show("El campo Precio debe ser un valor numérico.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Convertir la cantidad a entero
            if (!int.TryParse(txtCantidad.Text, out int cantidad))
            {
                MessageBox.Show("El campo cantidad debe ser un valor numérico.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Crear un nuevo producto con los datos ingresados
                Producto nuevoProducto = new Producto
                {
                    Id = txtId.Text,
                    Nombre = txtNombre.Text,
                    Descripcion = txtDescripcion.Text,
                    Precio = precio,
                    FechaCaducidad = dtpFechaCaducidad.Value,
                    Cantidad = cantidad
                };

                // Llamar al método para guardar el producto en la base de datos
                productoBL.RegistrarProducto(nuevoProducto);

                // Actualizar DataGridView
                CargarDatos();

                // Mensaje de Confirmacion
                MessageBox.Show("Producto registrado con éxito.", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                // Mensaje de Error
                MessageBox.Show("Error al registrar el producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDatos()
        {
            DataTable productos = productoBL.ObtenerListaProductos();
            dtvRegistroDatos.DataSource = productos;
        }

        // Limpiar campos al usar el boton Limpiar
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtId.Clear();
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtPrecio.Clear();
            txtCantidad.Clear();
            dtpFechaCaducidad.Value = DateTime.Today;
        }
    }
}