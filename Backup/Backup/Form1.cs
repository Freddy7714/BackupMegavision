using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Backup
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            // Desactivar clic del usuario
            this.Enabled = false;

            // Iniciar el proceso de respaldo
            await Task.Run(() => RealizarRespaldo());

            // Mostrar mensaje de finalización
            MessageBox.Show("El respaldo ha finalizado correctamente.", "Proceso Completado", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Activar clic del usuario
            this.Enabled = true;

            // Mostrar el botón para cerrar
            btnCerrar.Visible = true;
        }

        private void RealizarRespaldo()
        {
            try
            {
                this.Invoke((MethodInvoker)delegate
                {
                    // Mostrar mensaje de progreso
                    lblStatus.Text = "Haciendo Respaldo de Datos...";
                });

                /*string usuario = "Prueba";
                string fecha = DateTime.Now.ToString("dd-MM-yyyy");
                string sourcePath1 = @"C:\Users\Freddy\Desktop";
                //string sourcePath2 = @"C:\Users\Media Center\Documents";
                //string sourcePath3 = @"C:\Users\Media Center\Downloads";
                string destPath = $@"C:\Users\Freddy\Desktop\{fecha}_{usuario}\C\";
                */
                string usuario = "Milton Aparicio";
                string fecha = DateTime.Now.ToString("dd-MM-yyyy");
                string sourcePath1 = @"C:\Users\TufDash\Downloads";
                string sourcePath2 = @"C:\Users\TufDash\Documents";
                string sourcePath3 = @"C:\Users\TufDash\Desktop";
                string sourcePath4 = @"D:\";
                //string sourcePath5 = @"E:\";

                string destPath = $@"\\192.168.40.200\backup\MEGAVISION\NUEVOS\PRODUCCION\FANATICOS\MILTON\{fecha}_{usuario}";
                Directory.CreateDirectory(destPath);

                CopiarArchivos(sourcePath1, destPath);
                CopiarArchivos(sourcePath2, destPath);
                CopiarArchivos(sourcePath3, destPath);
                CopiarArchivos(sourcePath4, destPath);
                //CopiarArchivos(sourcePath5, destPath);


                this.Invoke((MethodInvoker)delegate
                {
                    // Actualizar barra de progreso
                    progressBar1.Value = 100;
                    lblStatus.Text = "Respaldo Completado";
                });
            }
            catch (Exception ex)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    lblStatus.Text = "Error durante el respaldo";
                });
            }
        }

        private void CopiarArchivos(string sourcePath, string destPath)
        {
            string[] extensionesPermitidas = { "*.xlsx", "*.xltx", "*.xltx", "*.xlsm", "*.xltm", "*.xlsb", "*.docm", "*.dotx", "*.dotm", "*.doc", "*.pst", "*.pdf", "*.ppt", "*.pptx", "*.ppa", "*.pptm", "*.potm", "*.sldx" };

            foreach (string extension in extensionesPermitidas)
            {
                try
                {
                    foreach (string file in Directory.GetFiles(sourcePath, extension, SearchOption.AllDirectories))
                    {
                        try
                        {
                            string destFile = Path.Combine(destPath, Path.GetFileName(file));

                            // Verificar si el archivo en destino existe y si el archivo fuente es más reciente
                            if (File.Exists(destFile))
                            {
                                DateTime sourceLastModified = File.GetLastWriteTime(file);
                                DateTime destLastModified = File.GetLastWriteTime(destFile);

                                if (sourceLastModified > destLastModified)
                                {
                                    // Si el archivo fuente es más reciente, reemplazar el archivo en destino
                                    File.Copy(file, destFile, true);
                                }
                            }
                            else
                            {
                                // Si el archivo no existe en destino, copiarlo
                                File.Copy(file, destFile, true);
                            }

                            // Actualizar barra de progreso (opcional)
                            this.Invoke((MethodInvoker)delegate
                            {
                                if (progressBar1.Value < progressBar1.Maximum - 1)
                                    progressBar1.Value++;
                            });
                        }
                        catch (UnauthorizedAccessException)
                        {
                            // Omitir archivos sin permisos de acceso
                            continue;
                        }
                        catch (Exception ex)
                        {
                            // Manejar otros errores de copia de archivos
                            MessageBox.Show($"Error al copiar el archivo '{file}': {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    // Omitir carpetas sin permisos de acceso
                    continue;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al acceder a la carpeta '{sourcePath}': {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }




        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Prevenir cierre del formulario mientras el respaldo está en proceso
            if (!this.Enabled)
            {
                e.Cancel = true;
            }
        }

        private void btnCerrar_Click_1(object sender, EventArgs e)
        {
            btnCerrar.Visible = true;
            this.Close();
        }
    }
}