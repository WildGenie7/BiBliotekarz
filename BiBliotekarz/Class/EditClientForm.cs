using System;
using System.Windows.Forms;

namespace BiBliotekarz.Class
{
    public partial class EditClientForm : Form
    {
        private readonly Client _client;

        public EditClientForm(Client client)
        {
            _client = client;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            Text = "Edytuj Klienta";
            Width = 400;
            Height = 400;

            var nameLabel = new Label { Text = "Imię", Top = 20, Left = 20 };
            var nameBox = new TextBox { Top = 20, Left = 150, Width = 200, Text = _client.Name };

            var surnameLabel = new Label { Text = "Nazwisko", Top = 60, Left = 20 };
            var surnameBox = new TextBox { Top = 60, Left = 150, Width = 200, Text = _client.Surname };

            var peselLabel = new Label { Text = "PESEL", Top = 100, Left = 20 };
            var peselBox = new TextBox { Top = 100, Left = 150, Width = 200, Text = _client.PESEL };

            var phoneLabel = new Label { Text = "Telefon", Top = 140, Left = 20 };
            var phoneBox = new TextBox { Top = 140, Left = 150, Width = 200, Text = _client.TelephoneNumber };

            var addressLabel = new Label { Text = "Adres", Top = 180, Left = 20 };
            var addressBox = new TextBox { Top = 180, Left = 150, Width = 200, Text = _client.HomeAddress };

            var saveButton = new Button { Text = "Zapisz", Top = 240, Left = 150 };

            saveButton.Click += (s, e) =>
            {
                try
                {
                    _client.Name = nameBox.Text;
                    _client.Surname = surnameBox.Text;
                    _client.PESEL = peselBox.Text;
                    _client.TelephoneNumber = phoneBox.Text;
                    _client.HomeAddress = addressBox.Text;

                    LibraryManager.UpdateClient(_client);
                    MessageBox.Show("Dane klienta zostały zaktualizowane!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Wystąpił błąd podczas zapisywania danych: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            Controls.Add(nameLabel);
            Controls.Add(nameBox);
            Controls.Add(surnameLabel);
            Controls.Add(surnameBox);
            Controls.Add(peselLabel);
            Controls.Add(peselBox);
            Controls.Add(phoneLabel);
            Controls.Add(phoneBox);
            Controls.Add(addressLabel);
            Controls.Add(addressBox);
            Controls.Add(saveButton);
        }
    }
}
