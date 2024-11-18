#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
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
    public class PresentationData
    {
        internal static List<PresentationData> presentationData;
        internal static string dropBoxValue;
        /// <summary>
        /// Initializes a new instance of the PresentationData class
        /// </summary>
        public PresentationData()
        {

        }
        /// <summary>
        /// Initializes a new instance of the PresentationData class
        /// </summary>
        /// <param name="Year">Year data</param>
        /// <param name="Jan">Jan month data</param>
        /// <param name="Feb">Feb month data</param>
        /// <param name="Mar">Mar month data</param>
        /// <param name="Apr">Apr month data</param>
        /// <param name="May">May month data</param>
        public PresentationData(int Year, int Jan, int Feb, int Mar, int Apr, int May)
            {
                this.Year = Year;
                this.Jan = Jan;
                this.Feb = Feb;
                this.Mar = Mar;
                this.Apr = Apr;
                this.May = May;
            }
        /// <summary>
        /// Add the default data to the collection. 
        /// </summary>
        /// <returns>Returns the collection of data</returns>
        public List<PresentationData> GetAllRecords()
        {
            List<PresentationData> order = new List<PresentationData>();
            order.Add(new PresentationData(2010, 60, 70, 80, 90, 100));
            order.Add(new PresentationData(2011, 80, 70, 60, 100, 90));
            order.Add(new PresentationData(2012, 60, 70, 80, 60, 90));
            order.Add(new PresentationData(2013, 90, 70, 80, 100, 90));
            return order;
        }
        /// <summary>
        /// Get or Set the year data from Grid
        /// </summary>
        public int? Year { get; set; }
        /// <summary>
        /// Get or Set the Jan month data from Grid
        /// </summary>
        public int? Jan { get; set; }
        /// <summary>
        /// Get or Set the Feb month data from Grid
        /// </summary>
        public int? Feb { get; set; }
        /// <summary>
        /// Get or Set the Mar month data from Grid
        /// </summary>
        public int? Mar { get; set; }
        /// <summary>
        /// Get or Set the Apr month data from Grid
        /// </summary>
        public int? Apr { get; set; }
        /// <summary>
        /// Get or Set the May month data from Grid
        /// </summary>
        public int? May { get; set; }
    }
}