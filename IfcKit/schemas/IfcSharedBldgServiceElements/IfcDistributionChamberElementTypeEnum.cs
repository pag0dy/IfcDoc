// This file may be edited manually or auto-generated using IfcKit at www.buildingsmart-tech.org.
// IFC content is copyright (C) 1996-2018 BuildingSMART International Ltd.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml.Serialization;


namespace BuildingSmart.IFC.IfcSharedBldgServiceElements
{
	public enum IfcDistributionChamberElementTypeEnum
	{
		[Description("Space formed in the ground for the passage of pipes, cables, ducts.")]
		FORMEDDUCT = 1,
	
		[Description("Chamber constructed on a drain, sewer or pipeline with a removable cover that per" +
	    "mits visble inspection.")]
		INSPECTIONCHAMBER = 2,
	
		[Description("Recess or chamber formed to permit access for inspection of substructure and serv" +
	    "ices.")]
		INSPECTIONPIT = 3,
	
		[Description("hamber constructed on a drain, sewer or pipeline with a removable cover that perm" +
	    "its the entry of a person.")]
		MANHOLE = 4,
	
		[Description("Chamber that houses a meter(s).")]
		METERCHAMBER = 5,
	
		[Description("Recessed or small chamber into which liquid is drained to facilitate its collecti" +
	    "on for removal.")]
		SUMP = 6,
	
		[Description("Excavated chamber, the length of which typically exceeds the width.")]
		TRENCH = 7,
	
		[Description("Chamber that houses a valve(s).")]
		VALVECHAMBER = 8,
	
		[Description("User-defined chamber type.")]
		USERDEFINED = -1,
	
		[Description("Undefined chamber type.")]
		NOTDEFINED = 0,
	
	}
}
