#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EJ2CoreSampleBrowser.Models
{
    public class State
    {
        public string StateName { get; set; }
        public string CountryId { get; set; }
        public string StateId { get; set; }
        public List<State> StateList()
        {
            List<State> state = new List<State>();
            state.Add(new State() { StateName = "New York", CountryId = "1", StateId = "101" });
            state.Add(new State() { StateName = "Queensland", CountryId = "2", StateId = "104" });
            state.Add(new State() { StateName = "Tasmania ", CountryId = "2", StateId = "105" });
            state.Add(new State() { StateName = "Victoria", CountryId = "2", StateId = "106" });
            state.Add(new State() { StateName = "Virginia ", CountryId = "1", StateId = "102" });
            state.Add(new State() { StateName = "Washington", CountryId = "1", StateId = "103" });
            return state;
        }
    }
}
