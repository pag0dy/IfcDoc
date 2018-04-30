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

using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcProductExtension;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcArchitectureDomain
{
	public partial class IfcRelInteractionRequirements : IfcRelConnects
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Number of interactions occurring on a daily basis. ")]
		public IfcCountMeasure? DailyInteraction { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("Represents the level of importance of interaction. 0 represents lowest importance, 1 represents highest importance.")]
		public IfcNormalisedRatioMeasure? ImportanceRating { get; set; }
	
		[DataMember(Order = 2)] 
		[Description("The location where this interaction happens. ")]
		public IfcSpatialStructureElement LocationOfInteraction { get; set; }
	
		[DataMember(Order = 3)] 
		[Description("Related space program for the interaction requirement.")]
		[Required()]
		public IfcSpaceProgram RelatedSpaceProgram { get; set; }
	
		[DataMember(Order = 4)] 
		[Description("Relating space program for the interaction requirement.")]
		[Required()]
		public IfcSpaceProgram RelatingSpaceProgram { get; set; }
	
	
		public IfcRelInteractionRequirements(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcCountMeasure? __DailyInteraction, IfcNormalisedRatioMeasure? __ImportanceRating, IfcSpatialStructureElement __LocationOfInteraction, IfcSpaceProgram __RelatedSpaceProgram, IfcSpaceProgram __RelatingSpaceProgram)
			: base(__GlobalId, __OwnerHistory, __Name, __Description)
		{
			this.DailyInteraction = __DailyInteraction;
			this.ImportanceRating = __ImportanceRating;
			this.LocationOfInteraction = __LocationOfInteraction;
			this.RelatedSpaceProgram = __RelatedSpaceProgram;
			this.RelatingSpaceProgram = __RelatingSpaceProgram;
		}
	
	
	}
	
}
