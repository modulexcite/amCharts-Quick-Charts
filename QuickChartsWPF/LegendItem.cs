﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows;
using System.Windows.Data;

namespace AmCharts.Windows.QuickCharts
{
    // Note: This class is used to facilitate a workaround with Silverlight issue of displaying objects 
    // inherited from DependencyObject in ItemsControl

    /// <summary>
    /// Represents a single chart legend item.
    /// </summary>
    public class LegendItem : DependencyObject, ILegendItem
    {
        public LegendItem(ILegendItem originalItem)
        {
            OriginalItem = originalItem;

            SetBindings();
        }

        private void SetBindings()
        {
            Binding titleBinding = new Binding("Title");
            titleBinding.Source = OriginalItem;
            BindingOperations.SetBinding(this, LegendItem.TitleProperty, titleBinding);

            Binding brushBinding = new Binding("Brush");
            brushBinding.Source = OriginalItem;
            BindingOperations.SetBinding(this, LegendItem.BrushProperty, brushBinding);
        }

        /// <summary>
        /// Identifies <see cref="Title"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(
            "Title", typeof(string), typeof(LegendItem),
            new PropertyMetadata(null)
            );

        /// <summary>
        /// Gets or sets the title of the slice.
        /// This is a dependency property.
        /// </summary>
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        /// <summary>
        /// Identifies <see cref="Brush"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty BrushProperty = DependencyProperty.Register(
            "Brush", typeof(Brush), typeof(LegendItem),
            new PropertyMetadata(null)
            );

        /// <summary>
        /// Gets or sets brush for the slice.
        /// This is a dependency property.
        /// </summary>
        public Brush Brush
        {
            get { return (Brush)GetValue(BrushProperty); }
            set { SetValue(BrushProperty, value); }
        }

        /// <summary>
        /// Gets or sets original source object for this item.
        /// </summary>
        public ILegendItem OriginalItem
        {
            get;
            private set;
        }
    }
}
