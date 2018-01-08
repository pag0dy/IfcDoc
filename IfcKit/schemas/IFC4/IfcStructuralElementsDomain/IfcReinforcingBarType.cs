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
using BuildingSmart.IFC.IfcProfileResource;
using BuildingSmart.IFC.IfcSharedComponentElements;

namespace BuildingSmart.IFC.IfcStructuralElementsDomain
{
	[Guid("c46e7d75-e366-4cf2-839d-664d7f121513")]
	public partial class IfcReinforcingBarType : IfcReinforcingElementType
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcReinforcingBarTypeEnum _PredefinedType;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _NominalDiameter;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcAreaMeasure? _CrossSectionArea;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _BarLength;
	
		[DataMember(Order=4)] 
		[XmlAttribute]
		IfcReinforcingBarSurfaceEnum? _BarSurface;
	
		[DataMember(Order=5)] 
		[XmlAttribute]
		IfcLabel? _BendingShapeCode;
	
		[DataMember(Order=6)] 
		IList<IfcBendingParameterSelect> _BendingParameters = new List<IfcBendingParameterSelect>();
	
	
		[Description("Subtype of reinforcing bar.")]
		public IfcReinforcingBarTypeEnum PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
		[Description("The nominal diameter defining the cross-section size of the reinforcing bar.")]
		public IfcPositiveLengthMeasure? NominalDiameter { get { return this._NominalDiameter; } set { this._NominalDiameter = value;} }
	
		[Description("The effective cross-section area of the reinforcing bar.")]
		public IfcAreaMeasure? CrossSectionArea { get { return this._CrossSectionArea; } set { this._CrossSectionArea = value;} }
	
		[Description("The total length of the reinforcing bar. The total length of bended bars are calc" +
	    "ulated according to local standards with corrections for the bends.\r\n")]
		public IfcPositiveLengthMeasure? BarLength { get { return this._BarLength; } set { this._BarLength = value;} }
	
		[Description("Indicator for whether the bar surface is plain or textured.\r\n")]
		public IfcReinforcingBarSurfaceEnum? BarSurface { get { return this._BarSurface; } set { this._BarSurface = value;} }
	
		[Description(@"Shape code per a standard like ACI 315, ISO 3766, or a similar standard.  It is presumed that a single standard for defining the bar bending is used throughout the project and that this standard is referenced from the <em>IfcProject</em> object through the <em>IfcDocumentReference</em> mechanism.")]
		public IfcLabel? BendingShapeCode { get { return this._BendingShapeCode; } set { this._BendingShapeCode = value;} }
	
		[Description("Bending shape parameters.  Their meaning is defined by the bending shape code and" +
	    " the respective standard.")]
		public IList<IfcBendingParameterSelect> BendingParameters { get { return this._BendingParameters; } }
	
	
	}
	
}
