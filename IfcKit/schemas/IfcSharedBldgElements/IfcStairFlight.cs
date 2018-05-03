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

using BuildingSmart.IFC.IfcGeometricConstraintResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcProductExtension;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcStructuralAnalysisDomain;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcSharedBldgElements
{
	public partial class IfcStairFlight : IfcBuildingElement
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Number of the risers included in the stair flight  <blockquote class=\"change-ifc2x4\">IFC4 CHANGE  The attribute has been deprecated it shall only be exposed with a NIL value. Use <em>Pset_StairFlightCommon.NumberOfRisers</em> instead.</blockquote>")]
		public IfcInteger? NumberOfRisers { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("Number of treads included in the stair flight.  <blockquote class=\"change-ifc2x4\">IFC4 CHANGE  The attribute has been deprecated it shall only be exposed with a NIL value. Use <em>Pset_StairFlightCommon.NumberOfTreads</em> instead.</blockquote>")]
		public IfcInteger? NumberOfTreads { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("Vertical distance from tread to tread. The riser height is supposed to be equal for all stairs in a stair flight.    <blockquote class=\"change-ifc2x4\">IFC4 CHANGE  The attribute has been deprecated it shall only be exposed with a NIL value. Use <em>Pset_StairFlightCommon.RiserHeight</em> instead.</blockquote>")]
		public IfcPositiveLengthMeasure? RiserHeight { get; set; }
	
		[DataMember(Order = 3)] 
		[XmlAttribute]
		[Description("Horizontal distance from the front to the back of the tread. The tread length is supposed to be equal for all steps of the stair flight.    <blockquote class=\"change-ifc2x4\">IFC4 CHANGE  The attribute has been deprecated it shall only be exposed with a NIL value. Use <em>Pset_StairFlightCommon.TreadLength</em> instead.</blockquote>")]
		public IfcPositiveLengthMeasure? TreadLength { get; set; }
	
		[DataMember(Order = 4)] 
		[XmlAttribute]
		[Description("Predefined generic type for a stair flight that is specified in an enumeration. There may be a property set given specificly for the predefined types.  <blockquote class=\"note\">NOTE&nbsp; The <em>PredefinedType</em> shall only be used, if no <em>IfcStairFlightType</em> is assigned, providing its own <em>IfcStairFlightType.PredefinedType</em>.</blockquote>  <blockquote class=\"change-ifc2x4\">IFC4 CHANGE  The attribute has been added at the end of the entity definition.</blockquote> ")]
		public IfcStairFlightTypeEnum? PredefinedType { get; set; }
	
	
		public IfcStairFlight(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcObjectPlacement __ObjectPlacement, IfcProductRepresentation __Representation, IfcIdentifier? __Tag, IfcInteger? __NumberOfRisers, IfcInteger? __NumberOfTreads, IfcPositiveLengthMeasure? __RiserHeight, IfcPositiveLengthMeasure? __TreadLength, IfcStairFlightTypeEnum? __PredefinedType)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType, __ObjectPlacement, __Representation, __Tag)
		{
			this.NumberOfRisers = __NumberOfRisers;
			this.NumberOfTreads = __NumberOfTreads;
			this.RiserHeight = __RiserHeight;
			this.TreadLength = __TreadLength;
			this.PredefinedType = __PredefinedType;
		}
	
	
	}
	
}
