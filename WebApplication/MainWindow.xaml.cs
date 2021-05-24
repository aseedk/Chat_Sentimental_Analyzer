using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Data;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoDBTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        static Regex ValidEmailRegex = CreateValidEmailRegex();
        public MainWindow()
        {
            InitializeComponent();
            MongoHelper.ConnectToMongoService();
            /*
            var collections = MongoHelper.Database.GetCollection<BsonDocument>("Users");
            var usernamefilter = Builders<BsonDocument>.Filter.Eq("username", "Aseedk");
            var emailfilter = Builders<BsonDocument>.Filter.Eq("email", "aseedk@hotmail.com");
            var usernameCheck = collections.Find(usernamefilter).FirstOrDefault();
            var emailCheck = collections.Find(emailfilter).FirstOrDefault();
            if (usernameCheck != null || emailCheck != null)
            {
                MessageBox.Show("User Already Exists");
            }
            else
            {
                MessageBox.Show("Kaddi Wich Pwaya he");
            }
            //var Account_Details = firstDocument.ToList();
            //MessageBox.Show(firstDocument.ToString());
            /*var filter = Builders<BsonDocument>.Filter.Eq("user_account_id", 1);
            var documents = collections.Find(new BsonDocument()).ToList();
            foreach (BsonDocument doc in documents)
            {
                MessageBox.Show(doc.ToString());
            }
            collections = MongoHelper.Database.GetCollection<BsonDocument>("Users");
            MessageBox.Show(filter.ToString());
            var document = new BsonDocument
            {
                {"user_account_id", 1},
                {"first_name", "Aseed Ali"},
                {"last_name", "Khokhar"},
                {"email", "aseedk@hotmail.com"},
                {"username", "Aseedk"},
                {"password", "lulmao99"}
            };
            collections.InsertOneAsync(document);
            collections = MongoHelper.Database.GetCollection<BsonDocument>("Users");
            documents = collections.Find(new BsonDocument()).ToList();
            foreach (BsonDocument doc in documents)
            {
                MessageBox.Show(doc.ToString());
            }*/
        }

        private void SignIn(object sender, RoutedEventArgs e)
        {
            SignInError.Content = "";
            if (SignInUsername.Text == "" || SignInPassword.Password == "")
            {
                SignInError.Content = "* Missing Values";
            }
            if (!IsUsername(SignInUsername.Text))
            {
                SignInError.Content += "* Incorrect Username Syntax";
            }
            var collections = MongoHelper.Database.GetCollection<BsonDocument>("Users");
            var signInFilter = Builders<BsonDocument>.Filter.Eq("username", SignInUsername.Text);
            var usernameCheck = collections.Find(signInFilter).FirstOrDefault();
            if (usernameCheck == null)
            {
                SignInError.Content = "* Username Doesn't Exists";
            }
            else
            {
                var AccountObject = usernameCheck.Elements;
                var AccountDetailsList = AccountObject.ToList();
                if (SignInPassword.Password == AccountDetailsList[5].Value.ToString())
                {
                    MessageBox.Show("Account Logged In");
                    var window = new ChatWindow(SignInUsername.Text);
                    window.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Incorrect Password");
                }
            }
            
        }

        private void SignUp(object sender, RoutedEventArgs e)
        {
            SignUpError.Content = "";
            if (SignUpFirstName.Text == "" || SignUpLastName.Text == "" || SignUpEmail.Text == "" ||
                SignUpUsername.Text == "" || SignUpPassword.Password == "") {
                SignUpError.Content += "* Missing Values";
            }
            
            if (!EmailIsValid(SignUpEmail.Text))
            {
                SignUpError.Content += "* Email Syntax Not Correct";
            }

            if (!IsAlphabets(SignUpFirstName.Text) || !IsAlphabets(SignUpLastName.Text))
            {
                SignUpError.Content += "* Incorrect Name";
            }

            if (!IsUsername(SignUpUsername.Text))
            {
                SignUpError.Content += "* Incorrect Username Syntax";
            }
            if (SignUpFirstName.Text != "" && SignUpLastName.Text != "" && SignUpEmail.Text != "" &&
                SignUpUsername.Text != "" && SignUpPassword.Password != "")
            {
                var collections = MongoHelper.Database.GetCollection<BsonDocument>("Users");
                var usernamefilter = Builders<BsonDocument>.Filter.Eq("username", SignInUsername.Text);
                var emailfilter = Builders<BsonDocument>.Filter.Eq("email", SignUpEmail.Text);
                var usernameCheck = collections.Find(usernamefilter).FirstOrDefault();
                var emailCheck = collections.Find(emailfilter).FirstOrDefault();
                if (usernameCheck != null || emailCheck != null)
                {
                    SignUpError.Content = "* User Already Exists";
                    MessageBox.Show("User Already Exists !!! ");
                }
                else
                {
                    collections = MongoHelper.Database.GetCollection<BsonDocument>("Users");
                    var document = new BsonDocument
                    {
                        {"first_name", SignUpFirstName.Text},
                        {"last_name", SignUpLastName.Text},
                        {"email", SignUpEmail.Text},
                        {"username", SignUpUsername.Text},
                        {"password", SignUpPassword.Password}
                    };
                    collections.InsertOneAsync(document);
                    MessageBox.Show("User Account Registered !!! ");
                }
            }
        }
        private static Regex CreateValidEmailRegex()
        {
            string validEmailPattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                                       + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                                       + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            return new Regex(validEmailPattern, RegexOptions.IgnoreCase);
        }

        private static bool EmailIsValid(string emailAddress)
        {
            var isValid = ValidEmailRegex.IsMatch(emailAddress);

            return isValid;
        }
        public bool IsAlphabets(string inputString)
        {
            Regex r = new Regex("^[a-zA-Z ]+$");
            if (r.IsMatch(inputString))
                return true;
            else
                return false;
        }
        public bool IsAlphaNumeric(string inputString)
        {
            Regex r = new Regex("^[a-zA-Z0-9]*$");
            if (r.IsMatch(inputString))
                return true;
            else
                return false;
        }
        private bool IsUsername(string inputString)
        {
            if (inputString.Length > 5 && inputString.Length < 12 && IsAlphaNumeric(inputString))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
    public class TextInputToVisibilityConverter : IMultiValueConverter
    {
        public object Convert( object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture )
        {
            if (!(values[0] is bool) || !(values[1] is bool)) return Visibility.Visible;
            var hasText = !(bool)values[0];
            var hasFocus = (bool)values[1];

            if (hasFocus || hasText)
                return Visibility.Collapsed;

            return Visibility.Visible;
        }


        public object[] ConvertBack( object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture )
        {
            throw new NotImplementedException();
        }
    } 
}