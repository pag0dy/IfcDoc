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

using BuildingSmart.IFC.IfcGeometricConstraintResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcProductExtension;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcStructuralAnalysisDomain;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcSharedBldgElements
{
	[Guid("c9d3cb6e-0d99-4b3e-bf59-208b93718306")]
	public partial class IfcStairFlight : IfcBuildingElement
	{
		[DataMember(Order=0)] 
		Int64? _NumberOfRiser;
	
		[DataMember(Order=1)] 
		Int64? _NumberOfTreads;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _RiserHeight;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _TreadLength;
	
	
		public IfcStairFlight()
		{
		}
	
		public IfcStairFlight(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcObjectPlacement __ObjectPlacement, IfcProductRepresentation __Representation, IfcIdentifier? __Tag, Int64? __NumberOfRiser, Int64? __NumberOfTreads, IfcPositiveLengthMeasure? __RiserHeight, IfcPositiveLengthMeasure? __TreadLength)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType, __ObjectPlacement, __Representation, __Tag)
		{
			this._NumberOfRiser = __NumberOfRiser;
			this._NumberOfTreads = __NumberOfTreads;
			this._RiserHeight = __RiserHeight;
			this._TreadLength = __TreadLength;
		}
	
		[Description("Number of the risers included in the stair flight.")]
		public Int64? NumberOfRiser { get { return this._NumberOfRiser; } set { this._NumberOfRiser = value;} }
	
		[Description("Number of treads included in the stair flight.")]
		public Int64? NumberOfTreads { get { return this._NumberOfTreads; } set { this._NumberOfTreads = value;} }
	
		[Description("Vertical distance from tread to tread. The riser height is supposed to be equal f" +
	    "or all stairs in a stair flight.")]
		public IfcPositiveLengthMeasure? RiserHeight { get { return this._RiserHeight; } set { this._RiserHeight = value;} }
	
		[Description("Horizontal distance from the front to the back of the tread. The tread length is " +
	    "supposed to be equal for all steps of the stair flight.\r\n")]
		public IfcPositiveLengthMeasure? TreadLength { get { return this._TreadLength; } set { this._TreadLength = value;} }
	
	
	}
	
}
