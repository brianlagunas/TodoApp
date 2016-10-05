using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace TodoApp.Uwp.Views
{
    public sealed partial class TodoView : UserControl
    {
        public TodoView()
        {
            this.InitializeComponent();
            DataContext = this;
        }

        public int Number
        {
            get { return (int)GetValue(NumberProperty); }
            set { SetValue(NumberProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Number.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NumberProperty =
            DependencyProperty.Register("Number", typeof(int), typeof(TodoView), new PropertyMetadata(0));

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Title.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(TodoView), new PropertyMetadata(default(string)));

        public string Description
        {
            get { return (string)GetValue(DescriptionProperty); }
            set { SetValue(DescriptionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Description.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DescriptionProperty =
            DependencyProperty.Register("Description", typeof(string), typeof(TodoView), new PropertyMetadata(default(string)));

        public Visibility LayoutFormatVisibility = Visibility.Visible;

        public bool ShowMinimal
        {
            get { return (bool)GetValue(ShowMinimalProperty); }
            set
            {
                SetValue(ShowMinimalProperty, value);
            }
        }

        // Using a DependencyProperty as the backing store for ShowMinimal.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ShowMinimalProperty =
            DependencyProperty.Register("ShowMinimal", typeof(bool), typeof(TodoView), new PropertyMetadata(false, new PropertyChangedCallback(ChangeShowMinimal)));

        private static void ChangeShowMinimal(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            (source as TodoView).LayoutFormatVisibility = ((bool)e.NewValue == true) ? Visibility.Collapsed : Visibility.Visible;
            (source as TodoView).Bindings.Update();
        }
    }
}
