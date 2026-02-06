#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.EJ2.Diagrams;
using System.Collections.Generic;

namespace EJ2CoreSampleBrowser.Pages.Diagram
{
    public class SerpentineDiagramModel : PageModel
    {
        // Data source for the timeline, to be serialized and used by the client-side script
        public List<MedicalBreakthrough> MedicalBreakthroughs { get; set; }

        public DiagramSnapSettings SnapSettings { get; set; }

        public void OnGet()
        {
            // Initialize diagram settings
            SnapSettings = new DiagramSnapSettings { Constraints = SnapConstraints.None };

            // Populate the list of medical breakthroughs
            MedicalBreakthroughs = new List<MedicalBreakthrough>
            {
                new MedicalBreakthrough { Id = "1", Year = "1796", Title = "Smallpox Vaccine", Description = "Edward Jenner develops the first successful vaccine using cowpox, marking a historic milestone in immunology." },
                new MedicalBreakthrough { Id = "2", Year = "1846", Title = "First Use of Anesthesia", Description = "William T. G. Morton demonstrates ether anesthesia publicly, revolutionizing surgical procedures by enabling pain-free operations." },
                new MedicalBreakthrough { Id = "3", Year = "1865", Title = "Germ Theory of Disease", Description = "Louis Pasteur proves microorganisms cause disease, establishing the foundation of modern microbiology." },
                new MedicalBreakthrough { Id = "4", Year = "1882", Title = "Discovery of the Tuberculosis Bacterium", Description = "Robert Koch identifies Mycobacterium tuberculosis, paving the way for accurate TB diagnosis and effective treatment." },
                new MedicalBreakthrough { Id = "5", Year = "1895", Title = "Discovery of X-Rays", Description = "Wilhelm Röntgen discovers X-rays, transforming medical imaging and diagnostic practices worldwide." },
                new MedicalBreakthrough { Id = "6", Year = "1901", Title = "Classification of Blood Types", Description = "Karl Landsteiner classifies major blood groups (A, B, O), enabling safe and reliable blood transfusions." },
                new MedicalBreakthrough { Id = "7", Year = "1921", Title = "Discovery of Insulin", Description = "Frederick Banting and Charles Best isolate insulin, turning diabetes into a manageable chronic condition." },
                new MedicalBreakthrough { Id = "8", Year = "1923", Title = "Diphtheria Vaccine Developed", Description = "Widespread use of the diphtheria toxoid vaccine begins, drastically reducing deaths from the disease." },
                new MedicalBreakthrough { Id = "9", Year = "1928", Title = "Discovery of Penicillin", Description = "Alexander Fleming discovers the first true antibiotic, heralding the antibiotic era." },
                new MedicalBreakthrough { Id = "10", Year = "1935", Title = "Sulfonamides Introduced", Description = "Sulfonamides, the first synthetic antibiotics, are introduced to effectively treat diverse bacterial infections." },
                new MedicalBreakthrough { Id = "11", Year = "1953", Title = "DNA Structure Identified", Description = "James Watson and Francis Crick reveal the double-helix structure of DNA, laying the groundwork for modern genetics." },
                new MedicalBreakthrough { Id = "12", Year = "1955", Title = "Polio Vaccine Approved", Description = "Jonas Salk’s IPV is approved as safe and effective, drastically reducing global polio cases." },
                new MedicalBreakthrough { Id = "13", Year = "1960", Title = "Introduction of Oral Contraceptives", Description = "The FDA approves the first oral contraceptive pill, revolutionizing reproductive health and social norms." },
                new MedicalBreakthrough { Id = "14", Year = "1967", Title = "First Human Heart Transplant", Description = "Dr. Christiaan Barnard performs the first successful human heart transplant, redefining cardiac surgery." },
                new MedicalBreakthrough { Id = "15", Year = "1971", Title = "CT Scan Invented", Description = "Godfrey Hounsfield and Allan Cormack invent CT scanning, dramatically improving internal medical imaging." },
                new MedicalBreakthrough { Id = "16", Year = "1978", Title = "Birth of First IVF Baby", Description = "Louise Brown becomes the first baby born through IVF, marking a breakthrough in reproductive medicine." },
                new MedicalBreakthrough { Id = "17", Year = "1980", Title = "Smallpox Eradicated", Description = "WHO declares smallpox eradicated, a historic triumph of global vaccination efforts." },
                new MedicalBreakthrough { Id = "18", Year = "1983", Title = "HIV Identified", Description = "Luc Montagnier and Robert Gallo identify HIV as the virus responsible for AIDS." },
                new MedicalBreakthrough { Id = "19", Year = "1990", Title = "Launch of Human Genome Project", Description = "The Human Genome Project launches, aiming to map all human genes and revolutionize personalized medicine." },
                new MedicalBreakthrough { Id = "20", Year = "1996", Title = "Introduction of HAART for HIV", Description = "HAART becomes the standard HIV treatment, transforming it into a manageable chronic condition." }
            };
        }
    }

    // A model class to represent a single data point in the timeline
    public class MedicalBreakthrough
    {
        public string Id { get; set; }
        public string Year { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}