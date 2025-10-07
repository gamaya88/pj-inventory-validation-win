using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Win32;
using PJ.Inf.InventoryValidation.Win.Model.HelpDeskDb;
using PJ.Inf.InventoryValidation.Win.Model.Views;
using PJ.Inf.InventoryValidation.Win.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PJ.Inf.InventoryValidation.Win.Service
{
    public static class UtilService
    {
        public static string UsuarioDetectado()
        {
            return
                    Util.LoadConfig().User.IsNullOrEmpty()
                        ? SystemInformation.UserName.ToUpper()
                        : Util.LoadConfig().User;
        }

        public static void SetMaterialSkin(this MaterialForm materialForm)
        {
            MaterialSkinManager materialSkinManager;
            // Initialize MaterialSkinManager
            materialSkinManager = MaterialSkinManager.Instance;

            // Set this to false to disable backcolor enforcing on non-materialSkin components
            // This HAS to be set before the AddFormToManage()
            materialSkinManager.EnforceBackcolorOnAllComponents = true;

            // MaterialSkinManager properties
            materialSkinManager.AddFormToManage(materialForm);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Red800, Primary.Red900, Primary.Red300, Accent.Red700, TextShade.WHITE);
        }

        public static List<T> LeerEntidadesDesdeJson<T>(string nombreArchivo)
        {
            string ruta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data", nombreArchivo);
            if (!File.Exists(ruta))
                return new List<T>();

            string json = File.ReadAllText(ruta);
            return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
        }

        public static void Configurar(this DataGridView dataGridView)
        {
            dataGridView.AllowUserToResizeRows = false;
            dataGridView.AllowUserToResizeColumns = false;
            //dataGridView.AllowUserToOrderColumns = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AllowUserToAddRows = false;
            //dataGridView.AllowDrop = false;
            dataGridView.AutoGenerateColumns = false;
            dataGridView.MultiSelect = false;
            dataGridView.ReadOnly = true;
            dataGridView.RowHeadersVisible = false;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        public static bool KeyPressInteger(object sender, KeyPressEventArgs e, int maxLength)
        {
            bool handled = true;

            // Permitir dígitos (0-9)
            if (char.IsDigit(e.KeyChar))
            {
                handled = false;
            }

            // No permitir el punto decimal
            if (e.KeyChar == '.')
            {
                handled = true;
            }

            // Permitir teclas de control (como Backspace)
            if (char.IsControl(e.KeyChar))
            {
                handled = false;
            }

            // No permitir más de 5 dígitos
            if (((MaterialTextBox)sender).Text.Length >= maxLength)
            {
                handled = true;
            }

            return handled;
        }

        public static void EnviarEmailNoCoincideBienPatrimonial(List<string> correosDestino, BienPatrimonialView bienPatrimonial, string emailEnvio, string credencialEnvio, Usuario usuarioDetectado)
        {

            string tablaHtml = GenerarTablaHtml(bienPatrimonial);

            // ** Nueva lógica para incrustar la imagen desde una ruta local **
            string rutaImagenLocal = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "logo.png"); // Cambia esta ruta a la de tu imagen
            string contentId = "logoApp"; // Identificador único para la imagen

            // 1. Crea una vista alternativa para el cuerpo HTML del correo.
            AlternateView vistaHtml = AlternateView.CreateAlternateViewFromString(GenerarCuerpoEmail(tablaHtml, contentId, usuarioDetectado), null, "text/html");

            // 2. Crea un recurso vinculado (la imagen) a partir de la ruta local.
            LinkedResource recursoImagen = new LinkedResource(rutaImagenLocal, "image/png");
            recursoImagen.ContentId = contentId; // Asigna el identificador

            // 3. Añade la imagen a la vista HTML.
            vistaHtml.LinkedResources.Add(recursoImagen);

            // Configura tu cliente SMTP
            var smtpClient = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential(emailEnvio, credencialEnvio),
                EnableSsl = true
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress("no-reply@example.com", "SISTEMA DE INVENTARIO"),
                Subject = $"BIEN A INVENTARIAR NO COINCIDE - {bienPatrimonial.BptCodigoPatrimonial}",
                // Ya no necesitas IsBodyHtml ni Body si usas AlternateView
            };
            mailMessage.AlternateViews.Add(vistaHtml);

            foreach (var correo in correosDestino)
            {
                mailMessage.To.Add(correo);
            }

            try
            {
                smtpClient.Send(mailMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al enviar correo: {ex.Message}");
            }
        }

        private static string GenerarCuerpoEmail(string tablaHtml, string imagenCid, Usuario usuarioDetectado)
        {
            string html = $@"
                <html>
                <body>
                    <h1>USUARIO REPORTA QUE EL BIEN NO CORRESPONDE A LO CONSTATADO</h1>
                    <p>El siguiente bien no corresponde a la constatación visual, según lo informado por {usuarioDetectado.Per.PerNombres} {usuarioDetectado.Per.PerApellidoPaterno}</p>
                    <img src='cid:{imagenCid}' alt='Logo de la aplicación' style='width:150px; height:auto;'/>
                    <br>
                    {tablaHtml}
                </body>
                </html>
            ";
            return html;
        }

        private static string GenerarTablaHtml(BienPatrimonialView bienPatrimonial)
        {
            var sb = new StringBuilder();
            sb.AppendLine("<table border='1' style='border-collapse: collapse;'>");
            
            sb.AppendLine("<tbody>");

            sb.AppendLine($"<tr><td>CÓD. PATRIMONIAL</td><td>{bienPatrimonial.BptCodigoPatrimonial}</td></tr>");
            sb.AppendLine($"<tr><td>MARCA</td><td>{bienPatrimonial.MarDescripcion}</td></tr>");
            sb.AppendLine($"<tr><td>MODELO</td><td>{bienPatrimonial.ModDescripcion}</td></tr>");
            sb.AppendLine($"<tr><td>BIEN</td><td>{bienPatrimonial.DebDescripcion}</td></tr>");
            sb.AppendLine($"<tr><td>SERIE</td><td>{bienPatrimonial.BptSerie}</td></tr>");
            sb.AppendLine($"<tr><td>OBSERVACIÓN</td><td>{bienPatrimonial.BptObservacion}</td></tr>");

            sb.AppendLine("</tbody>");
            sb.AppendLine("</table>");
            return sb.ToString();
        }
    }
}
