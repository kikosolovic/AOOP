using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using System.IO;
using Avalonia.Controls.Shapes;
using Avalonia.Media;
using Avalonia.Layout;
using System.Collections.Generic;
using System.Linq;

namespace AvaloniaExercises;

public partial class MainWindow : Window
{
    public char[] bitmap;
    private Dictionary<string, Button> buttonDictionary = new Dictionary<string, Button>();

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
        // Console.WriteLine(this.FindControl<Button>("kokot").Content);
    }

    private void load(object sender, RoutedEventArgs e, bool flipped = false)
    {


        var StackPanel = this.FindControl<StackPanel>("ImageStack");
        StackPanel.Children.Clear();


        string PATH = Environment.CurrentDirectory + "/Assets/" + (this.FindControl<TextBox>("fileName").Text);


        if (!File.Exists(PATH))
        {
            Console.WriteLine("File not found");
            return;
        }

        StreamReader sr = new StreamReader(PATH);
        string text = sr.ReadToEnd();
        bitmap = text.ToCharArray();
        int height = int.Parse(bitmap[0].ToString());
        int width = int.Parse(bitmap[2].ToString());

        if (flipped)
        {
            int split = 4;

            char[] dimensions = new char[split];
            char[] values = new char[bitmap.Length - split];

            Array.Copy(bitmap, dimensions, split);
            Array.Copy(bitmap, split, values, 0, bitmap.Length - split);

            List<char[]> rows = new List<char[]>();

            for (int i = 0; i < height; i++)
            {
                char[] row = new char[width];
                Array.Copy(values, i * width, row, 0, width);
                rows.Add(row);
            }

            rows.Reverse();

            bitmap = (dimensions.Concat(rows.SelectMany(row => row)).ToArray());



        }
        int buttonRow = height + 1;

        var grid = new Grid()
        {
            Background = Brushes.White,
        };

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
                var num = start.ToString();
                var button = new Button()
                {
                    Background = bitmap[start] == '0' ? Brushes.White : Brushes.Black,
                    Name = num,
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    VerticalAlignment = VerticalAlignment.Stretch,


                };
                button.Click += (sender, e) => changeColor(sender, e, num);
                buttonDictionary[num] = button;



                Grid.SetRow(button, i);
                Grid.SetColumn(button, j);
                grid.Children.Add(button);

                start = start + 1;
            }
        }



        StackPanel.Children.Add(grid);

    }

    private void changeColor(object sender, EventArgs e, string x)
    {
        if (buttonDictionary.TryGetValue(x, out Button button))
        {
            button.Background = bitmap[int.Parse(x)] == '1' ? Brushes.White : Brushes.Black;
            bitmap[int.Parse(x)] = bitmap[int.Parse(x)] == '1' ? '0' : '1';
        }
        else
        {
            Console.WriteLine("Thi button is null");
        }
    }

    private void loadFlipped(object sender, RoutedEventArgs e)
    {
        load(sender, e, true);
    }
    private void loadUnFlipped(object sender, RoutedEventArgs e)
    {
        load(sender, e);
    }
    private void export(object sender, RoutedEventArgs e)
    {
        string PATH = Environment.CurrentDirectory + "/Assets/" + (this.FindControl<TextBox>("fileName").Text);

        string res = "";
        foreach (var item in bitmap)
        {
            res = res + item.ToString();
        }
        // Console.WriteLine(res);
        File.WriteAllText(PATH, res);
    }

}
