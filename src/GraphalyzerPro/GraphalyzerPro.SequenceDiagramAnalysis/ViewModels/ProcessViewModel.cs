﻿/*
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

using System.Linq;
using GraphalyzerPro.Common.Interfaces;
using ReactiveUI;

namespace GraphalyzerPro.SequenceDiagramAnalysis.ViewModels
{
    internal class ProcessViewModel : ReactiveObject, IProcessViewModel
    {
        private readonly ReactiveCollection<IDiagnoseOutputEntry> _diagnoseOutputEntries;
        private readonly ReactiveDerivedCollection<IThreadViewModel> _threads;

        public ProcessViewModel(int processId)
        {
            _diagnoseOutputEntries = new ReactiveCollection<IDiagnoseOutputEntry>();

            _threads =
                DiagnoseOutputEntries.CreateDerivedCollection(
                    x => new ThreadViewModel(x.ThreadNumber) as IThreadViewModel, entry =>
                    {
                        if(Threads.Any(x => x.Number == entry.ThreadNumber))
                        {
                            Threads.Single(x => x.Number == entry.ThreadNumber).ProcessNewDiagnoseOutputEntry(entry);
                            return false;
                        }
                        return true;
                    });

            Id = processId;
        }

        public int Id { get; private set; }

        public ReactiveDerivedCollection<IThreadViewModel> Threads
        {
            get { return _threads; }
            set { this.RaiseAndSetIfChanged(value); }
        }

        public ReactiveCollection<IDiagnoseOutputEntry> DiagnoseOutputEntries
        {
            get { return _diagnoseOutputEntries; }
            private set { this.RaiseAndSetIfChanged(value); }
        }

        public void ProcessNewDiagnoseOutputEntry(IDiagnoseOutputEntry diagnoseOutputEntry)
        {
            DiagnoseOutputEntries.Add(diagnoseOutputEntry);
        }
    }
}