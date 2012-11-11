using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfOutlookBar.Test
{
    public class OutlookBar : Grid
    {
        private StackPanel _navigation;
        private StackPanel _function;

        public OutlookBar()
        {
            DefaultSize();
            CreateRows();
            CreateContainer();
            InitList();
        }

        void InitList()
        {
            NavigationCommands = new ObservableCollection<FrameworkElement>();
            NavigationCommands.CollectionChanged += NavigationBar_CollectionChanged;
        }        

        void NavigationBar_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            _navigation.Children.Clear();
            foreach (var function in NavigationCommands)
            {
                _navigation.Children.Add(function);
            }
        }

        void DefaultSize()
        {
            MinHeight = 200;
            MinWidth = 100;
        }

        void CreateRows()
        {
            //1. Reihe für Text ohne ohne Text
            this.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
            //2. Reihe für Context Funktionen
            this.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            //3. Reihe für Basis Navigation
            this.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
        }

        void CreateContainer()
        {
            _navigation = new StackPanel { HorizontalAlignment = HorizontalAlignment.Stretch,MinHeight=100, Background = new SolidColorBrush(Colors.Blue)};
            _function = new StackPanel
                            {
                                HorizontalAlignment = HorizontalAlignment.Stretch,
                                MinHeight = 100,
                                Background = new SolidColorBrush(Colors.Red),                                
                               
                            };

            CheckBox checkBox = new CheckBox();
            _function.Children.Add(checkBox);

            Children.Add(_navigation);
            Children.Add(_function);

            SetRow(_function, 1);
            SetRow(_navigation, 2);
        }

        public static readonly DependencyProperty NavigationCommandsProperty = DependencyProperty.Register("NavigationCommands", typeof(ObservableCollection<FrameworkElement>), typeof(OutlookBar));

        public ObservableCollection<FrameworkElement> NavigationCommands
        {
            get { return (ObservableCollection<FrameworkElement>)GetValue(NavigationCommandsProperty); }
            set { SetValue(NavigationCommandsProperty, value); }
        }        
    }
}
