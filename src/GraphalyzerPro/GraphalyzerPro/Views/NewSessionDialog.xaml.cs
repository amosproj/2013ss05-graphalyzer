/*
 * Copyright (c) 2006-2009 by Christoph Menzel, Daniel Birkmaier, 
 * Maximilian Madeja, Farruch Kouliev, Stefan Zoettlein
 *
 * This file is part of the GraphalyzerPro application.
 *
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU Affero General Public License as
 * published by the Free Software Foundation, either version 3 of the
 * License, or (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU Affero General Public License for more details.
 *
 * You should have received a copy of the GNU Affero General Public
 * License along with this program. If not, see
 * <http://www.gnu.org/licenses/>.
 */

using System;
using System.Windows;
using GraphalyzerPro.ViewModels;

namespace GraphalyzerPro.Views
{
    /// <summary>
    ///     Interaction logic for NewSessionDialog.xaml
    /// </summary>
    public partial class NewSessionDialog : Window
    {
        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(
            "ViewModel",
            typeof (INewSessionDialogViewModel),
            typeof (NewSessionDialog),
            new PropertyMetadata(default(INewSessionDialogViewModel))
            );

        public NewSessionDialog()
        {
            InitializeComponent();

            ViewModel = new NewSessionDialogViewModel();

            ViewModel.ApplyCommand.Subscribe(x =>
                {
                    DialogResult = true;
                    Close();
                });
        }

        public INewSessionDialogViewModel ViewModel
        {
            get { return (INewSessionDialogViewModel) GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }
    }
}