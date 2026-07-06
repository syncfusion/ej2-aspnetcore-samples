using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.EJ2.Diagrams;
using System.Text.Json;

namespace EJ2CoreSampleBrowser.Pages.Diagram;

public class ErDiagramModel : PageModel
{
    public string SchemaJson { get; set; } = "{}";

	public void OnGet()
	{
		var colorTokens = new
		{
			primary = new { headerFill = "#bfdbfe", bodyFill = "#eff6ff", strokeColor = "#2563eb", connectorColor = "#2563eb" },
			secondary = new { headerFill = "#bbf7d0", bodyFill = "#f0fdf4", strokeColor = "#16a34a", connectorColor = "#16a34a" },
			tertiary = new { headerFill = "#ddd6fe", bodyFill = "#f5f3ff", strokeColor = "#7c3aed", connectorColor = "#7c3aed" },
			accent = new { headerFill = "#fdba74", bodyFill = "#fff7ed", strokeColor = "#ea580c", connectorColor = "#ea580c" },
			neutral = new { headerFill = "#d1d5db", bodyFill = "#f9fafb", strokeColor = "#6b7280", connectorColor = "#6b7280" },
			warning = new { headerFill = "#fde68a", bodyFill = "#fffbeb", strokeColor = "#d97706", connectorColor = "#d97706" }
		};

		var schema = new
		{
			title = "Hospital Appointment ER Diagram",

			entities = new object[]
			{
				new
				{
					id = "Doctor", title = "DOCTOR", color = "secondary", position = new { x = 0, y = 94 },
					fields = new object[]
					{
						new { id = "doctor_id", name = "DoctorID", isPrimaryKey = true },
						new { id = "doctor_name", name = "Name" },
						new { id = "department", name = "Department" },
						new { id = "specialization", name = "Specialization" },
						new { id = "contact_number", name = "ContactNumber" }
					}
				},
				new
				{
					id = "Patient", title = "PATIENT", color = "primary", position = new { x = 290, y = 83 },
					fields = new object[]
					{
						new { id = "patient_id", name = "PatientID", isPrimaryKey = true },
						new { id = "patient_name", name = "Name" },
						new { id = "date_of_birth", name = "DateOfBirth" },
						new { id = "patient_gender", name = "Gender" },
						new { id = "patient_blood_group", name = "BloodGroup" },
						new { id = "patient_contact_number", name = "ContactNumber" }
					}
				},
				new
				{
					id = "Appointment", title = "APPOINTMENT", color = "tertiary", position = new { x = 133, y = 355 },
					fields = new object[]
					{
						new { id = "appointment_id", name = "AppointmentID", isPrimaryKey = true },
						new { id = "app_doctor_id", name = "DoctorID", isForeignKey = true },
						new { id = "app_patient_id", name = "PatientID", isForeignKey = true },
						new { id = "appointment_date", name = "AppointmentDate" },
						new { id = "status", name = "Status" }
					}
				},
				new
				{
					id = "Diagnosis", title = "DIAGNOSIS", color = "accent", position = new { x = 549, y = 236 },
					fields = new object[]
					{
						new { id = "diagnosis_id", name = "DiagnosisID", isPrimaryKey = true },
						new { id = "diag_appointment_id", name = "AppointmentID", isForeignKey = true },
						new { id = "disease", name = "Disease" },
						new { id = "severity", name = "Severity" },
						new { id = "notes", name = "Notes" }
					}
				},
				new
				{
					id = "Prescription", title = "PRESCRIPTION", color = "warning", position = new { x = 384, y = 493 },
					fields = new object[]
					{
						new { id = "prescription_id", name = "PrescriptionID", isPrimaryKey = true },
						new { id = "pres_diagnosis_id", name = "DiagnosisID", isForeignKey = true },
						new { id = "medicine", name = "Medicine" },
						new { id = "dosage", name = "Dosage" },
						new { id = "frequency", name = "Frequency" },
						new { id = "duration_days", name = "DurationDays" }
					}
				}
			},

			relationships = new object[]
			{
				new
				{
					id = "rel_doctor_appointment",
					source = "Doctor",
					target = "Appointment",
                    sourceCardinality = "OneAndOnlyOne",
					targetCardinality = "ZeroOrMany",
					relationshipType = "NonIdentifying",
					color = "#16a34a",
					annotation = "attends"
				},
				new
				{
					id = "rel_patient_appointment",
					source = "Patient",
					target = "Appointment",
					sourceCardinality = "OneAndOnlyOne",
					targetCardinality = "ZeroOrMany",
					relationshipType = "NonIdentifying",
					color = "#2563eb",
					annotation = "books"
				},
				new
				{
					id = "rel_appointment_diagnosis",
					source = "Appointment",
					target = "Diagnosis",
					sourceCardinality = "OneAndOnlyOne",
					targetCardinality = "ZeroOrMany",
					relationshipType = "Identifying",
					color = "#7c3aed",
					annotation = "leads to"
				},
				new
				{
					id = "rel_diagnosis_prescription",
					source = "Diagnosis",
					target = "Prescription",
					sourceCardinality = "OneAndOnlyOne",
					targetCardinality = "ZeroOrMany",
					relationshipType = "Identifying",
					color = "#ea580c",
					annotation = "generates"
				}
			}

		};

		SchemaJson = JsonSerializer.Serialize(schema);
	}
}
