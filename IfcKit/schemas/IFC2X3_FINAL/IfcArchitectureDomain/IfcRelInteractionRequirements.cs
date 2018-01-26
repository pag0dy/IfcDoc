// This file was automatically generated from IFCDOC at www.buildingsmart-tech.org.
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
	[Guid("fb93ae0f-ebff-4dd4-8c7f-b8a9fe4099d4")]
	public partial class IfcRelInteractionRequirements : IfcRelConnects
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcCountMeasure? _DailyInteraction;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcNormalisedRatioMeasure? _ImportanceRating;
	
		[DataMember(Order=2)] 
		IfcSpatialStructureElement _LocationOfInteraction;
	
		[DataMember(Order=3)] 
		[Required()]
		IfcSpaceProgram _RelatedSpaceProgram;
	
		[DataMember(Order=4)] 
		[Required()]
		IfcSpaceProgram _RelatingSpaceProgram;
	
	
		public IfcRelInteractionRequirements()
		{
		}
	
		public IfcRelInteractionRequirements(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcCountMeasure? __DailyInteraction, IfcNormalisedRatioMeasure? __ImportanceRating, IfcSpatialStructureElement __LocationOfInteraction, IfcSpaceProgram __RelatedSpaceProgram, IfcSpaceProgram __RelatingSpaceProgram)
			: base(__GlobalId, __OwnerHistory, __Name, __Description)
		{
			this._DailyInteraction = __DailyInteraction;
			this._ImportanceRating = __ImportanceRating;
			this._LocationOfInteraction = __LocationOfInteraction;
			this._RelatedSpaceProgram = __RelatedSpaceProgram;
			this._RelatingSpaceProgram = __RelatingSpaceProgram;
		}
	
		[Description("Number of interactions occurring on a daily basis. ")]
		public IfcCountMeasure? DailyInteraction { get { return this._DailyInteraction; } set { this._DailyInteraction = value;} }
	
		[Description("Represents the level of importance of interaction. 0 represents lowest importance" +
	    ", 1 represents highest importance.")]
		public IfcNormalisedRatioMeasure? ImportanceRating { get { return this._ImportanceRating; } set { this._ImportanceRating = value;} }
	
		[Description("The location where this interaction happens. ")]
		public IfcSpatialStructureElement LocationOfInteraction { get { return this._LocationOfInteraction; } set { this._LocationOfInteraction = value;} }
	
		[Description("Related space program for the interaction requirement.")]
		public IfcSpaceProgram RelatedSpaceProgram { get { return this._RelatedSpaceProgram; } set { this._RelatedSpaceProgram = value;} }
	
		[Description("Relating space program for the interaction requirement.")]
		public IfcSpaceProgram RelatingSpaceProgram { get { return this._RelatingSpaceProgram; } set { this._RelatingSpaceProgram = value;} }
	
	
	}
	
}
