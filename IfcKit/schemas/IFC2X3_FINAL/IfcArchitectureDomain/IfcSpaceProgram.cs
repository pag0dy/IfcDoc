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
	[Guid("d4a072dd-513c-42b9-bca3-97a683fdfb56")]
	public partial class IfcSpaceProgram : IfcControl
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcIdentifier _SpaceProgramIdentifier;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcAreaMeasure? _MaxRequiredArea;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcAreaMeasure? _MinRequiredArea;
	
		[DataMember(Order=3)] 
		IfcSpatialStructureElement _RequestedLocation;
	
		[DataMember(Order=4)] 
		[XmlAttribute]
		[Required()]
		IfcAreaMeasure _StandardRequiredArea;
	
		[InverseProperty("RelatedSpaceProgram")] 
		ISet<IfcRelInteractionRequirements> _HasInteractionReqsFrom = new HashSet<IfcRelInteractionRequirements>();
	
		[InverseProperty("RelatingSpaceProgram")] 
		ISet<IfcRelInteractionRequirements> _HasInteractionReqsTo = new HashSet<IfcRelInteractionRequirements>();
	
	
		public IfcSpaceProgram()
		{
		}
	
		public IfcSpaceProgram(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcIdentifier __SpaceProgramIdentifier, IfcAreaMeasure? __MaxRequiredArea, IfcAreaMeasure? __MinRequiredArea, IfcSpatialStructureElement __RequestedLocation, IfcAreaMeasure __StandardRequiredArea)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType)
		{
			this._SpaceProgramIdentifier = __SpaceProgramIdentifier;
			this._MaxRequiredArea = __MaxRequiredArea;
			this._MinRequiredArea = __MinRequiredArea;
			this._RequestedLocation = __RequestedLocation;
			this._StandardRequiredArea = __StandardRequiredArea;
		}
	
		[Description("Identifier for this space program. It often refers to a number (or code) assigned" +
	    " to the space program. Example: R-001.")]
		public IfcIdentifier SpaceProgramIdentifier { get { return this._SpaceProgramIdentifier; } set { this._SpaceProgramIdentifier = value;} }
	
		[Description("The maximum floor area programmed for this space (according to client requirement" +
	    "s)")]
		public IfcAreaMeasure? MaxRequiredArea { get { return this._MaxRequiredArea; } set { this._MaxRequiredArea = value;} }
	
		[Description("The minimum floor area programmed for this space (according to client requirement" +
	    "s)")]
		public IfcAreaMeasure? MinRequiredArea { get { return this._MinRequiredArea; } set { this._MinRequiredArea = value;} }
	
		[Description("Location within the building structure, requested for the space.")]
		public IfcSpatialStructureElement RequestedLocation { get { return this._RequestedLocation; } set { this._RequestedLocation = value;} }
	
		[Description("The floor area programmed for this space (according to client requirements).")]
		public IfcAreaMeasure StandardRequiredArea { get { return this._StandardRequiredArea; } set { this._StandardRequiredArea = value;} }
	
		[Description("Set of inverse relationships to space or work interaction requirement objects (FO" +
	    "R RelatedObject).")]
		public ISet<IfcRelInteractionRequirements> HasInteractionReqsFrom { get { return this._HasInteractionReqsFrom; } }
	
		[Description("Set of inverse relationships to space or work interaction requirements (FOR Relat" +
	    "ingObject).")]
		public ISet<IfcRelInteractionRequirements> HasInteractionReqsTo { get { return this._HasInteractionReqsTo; } }
	
	
	}
	
}
