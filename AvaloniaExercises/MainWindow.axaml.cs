using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using System.IO;
using Avalonia.Controls.Shapes;
using Avalonia.Media;
using Avalonia.Layout;

namespace AvaloniaExercises;

public partial class MainWindow : Window
{
    public char[] bitmap;
    public MainWindow()
    {
        InitializeComponent();
        this.Width = 600;
        this.Height = 500;
    }
    private void Exercise2ShowOutput_Click(object sender, RoutedEventArgs e)
    {
        var textBox = this.FindControl<TextBox>("Exercise2TextBox");
        var comboBox = this.FindControl<ComboBox>("Exercise2ComboBox");
        var outputTextBlock = this.FindControl<TextBlock>("OutputTextBlock");
        var CB = this.FindControl<CheckBox>("CB1");
        string output = $"TextBox: {textBox.Text}, ComboBox: {comboBox.SelectionBoxItem}, Checkbox checked: {CB.IsChecked}";
        outputTextBlock.Text = output;
    }

    private void Exercise3ShowImage_Click(object sender, RoutedEventArgs e)
    {
        var catRadioButton = this.FindControl<RadioButton>("CatRadioButton");
        var animalImage = this.FindControl<Image>("AnimalImage");

        if (catRadioButton.IsChecked == true)
        {

            animalImage.Source = new Bitmap(AssetLoader.Open(new Uri("avares://AvaloniaExercises/Assets/cat.jpg")));

        }
        var dogRadioButton = this.FindControl<RadioButton>("DogRadioButton");

        if (dogRadioButton.IsChecked == true)
        {

            animalImage.Source = new Bitmap(AssetLoader.Open(new Uri("avares://AvaloniaExercises/Assets/dog.jpg")));

        }
        var birdRadioButton = this.FindControl<RadioButton>("BirdRadioButton");

        if (birdRadioButton.IsChecked == true)
        {

            animalImage.Source = new Bitmap(AssetLoader.Open(new Uri("avares://AvaloniaExercises/Assets/bird.jpg")));

        }

    }
    private void add(object sender, RoutedEventArgs e)
    {
        string num1 = (this.FindControl<TextBlock>("n1").Text);
        string num2 = this.FindControl<TextBlock>("n2").Text;

        int res = (int.Parse(num1) + int.Parse(num2));

        this.FindControl<TextBox>("res").Text = res.ToString();
    }

    private void load(object sender, RoutedEventArgs e)
    {
        string PATH = Environment.CurrentDirectory + "/Assets/" + (this.FindControl<TextBox>("fileName").Text);
        var textBlock = new TextBlock { Text = "kokot" };

        StreamReader sr = new StreamReader(PATH);
        string text = sr.ReadToEnd();
        char[] pr = text.ToCharArray();
        bitmap = text.ToCharArray();
        int height = int.Parse(pr[0].ToString());
        int width = int.Parse(pr[2].ToString());



        Console.WriteLine(width);
        var grid = new Grid() { Background = Brushes.White };

        for (int i = 0; i < height; i++)
        {
            grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Star });
        }

        for (int j = 0; j < width; j++)
        {
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
        }



        int start = 4;
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                var button = new Button()
                {
                    Background = pr[start] == '0' ? Brushes.White : Brushes.Black,
                    // OnClick = pr[start] == '0' ? Brushes.White : Brushes.Black,

                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    VerticalAlignment = VerticalAlignment.Stretch,

                };

                // button.Click += (s, e) => ChangeColor(color = pr[start], id = start);

                // var button = CreateButton(pr[start]);



                Grid.SetRow(button, i);
                Grid.SetColumn(button, j);
                grid.Children.Add(button);

                start = start + 1;
            }
        }







        this.Content = grid;

    }
    // private void ChangeColor(string color, int id)
    // {
    //     bitmap[id] = color == "0" ? '1' : '0';
    // }
}
