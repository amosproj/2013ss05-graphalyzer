﻿/*
 * Copyright (c) 2006-2009 by Christoph Menzel, Daniel Birkmaier, 
 * Carl-Clemens Ebinger, Maximilian Madeja, Farruch Kouliev, Stefan Zoettlein
 *
 * This file is part of the GraphalyzerPro rating application.
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

using GraphalyzerPro.ViewModels;
using Microsoft.Practices.Unity;

namespace GraphalyzerPro
{
    public class ViewModelLocator
    {
        private readonly static UnityContainer unityContainer = new UnityContainer();

        public ViewModelLocator()
        {
            unityContainer.RegisterType<IMainViewModel, MainViewModel>();
        }

        public static T Resolve<T>() where T : class
        {
            return unityContainer.Resolve<T>();
        }

        public static T Resolve<T>(string name) where T : class
        {
            return unityContainer.Resolve<T>(name);
        }

        public IMainViewModel MainViewModel
        {
            get { return unityContainer.Resolve<IMainViewModel>(); }
        }
    }
}