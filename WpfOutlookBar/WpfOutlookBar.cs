using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfOutlookBar
{
    public class WpfOutlookBar : Grid
    {
        private StackPanel _navigation;
        private StackPanel _function;

        public override void BeginInit()
        {           
            DefaultSize();
            CreateRows();
            CreateContainer();  
        }

        void DefaultSize()
        {
            MinHeight = 200;
            MinWidth = 100;   
        }

        void CreateRows()
        {
            //1. Reihe für Text ohne ohne Text
            this.RowDefinitions.Add(new RowDefinition{Height = new GridLength(1,GridUnitType.Auto)});
            //2. Reihe für Context Funktionen
            this.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star)});
            //3. Reihe für Basis Navigation
            this.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto)});
        }

        void CreateContainer()
        {
            _navigation = new StackPanel{HorizontalAlignment=HorizontalAlignment.Stretch};
            _function = new StackPanel { HorizontalAlignment = HorizontalAlignment.Stretch };

            SetRow(_function, 1);
            SetRow(_navigation, 2);
        }
    }
}
