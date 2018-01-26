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

using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcProductExtension;
using BuildingSmart.IFC.IfcSharedComponentElements;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcStructuralElementsDomain
{
	[Guid("66a6e642-3b24-4796-a6a3-8045c9ee3b54")]
	public partial class IfcTendonType : IfcReinforcingElementType
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcTendonTypeEnum _PredefinedType;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _NominalDiameter;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcAreaMeasure? _CrossSectionArea;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _SheathDiameter;
	
	
		public IfcTendonType()
		{
		}
	
		public IfcTendonType(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcIdentifier? __ApplicableOccurrence, IfcPropertySetDefinition[] __HasPropertySets, IfcRepresentationMap[] __RepresentationMaps, IfcLabel? __Tag, IfcLabel? __ElementType, IfcTendonTypeEnum __PredefinedType, IfcPositiveLengthMeasure? __NominalDiameter, IfcAreaMeasure? __CrossSectionArea, IfcPositiveLengthMeasure? __SheathDiameter)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ApplicableOccurrence, __HasPropertySets, __RepresentationMaps, __Tag, __ElementType)
		{
			this._PredefinedType = __PredefinedType;
			this._NominalDiameter = __NominalDiameter;
			this._CrossSectionArea = __CrossSectionArea;
			this._SheathDiameter = __SheathDiameter;
		}
	
		[Description("Subtype of tendon.")]
		public IfcTendonTypeEnum PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
		[Description("The nominal diameter defining the cross-section size of the prestressed part of t" +
	    "he tendon.")]
		public IfcPositiveLengthMeasure? NominalDiameter { get { return this._NominalDiameter; } set { this._NominalDiameter = value;} }
	
		[Description("The effective cross-section area of the prestressed part of the tendon.")]
		public IfcAreaMeasure? CrossSectionArea { get { return this._CrossSectionArea; } set { this._CrossSectionArea = value;} }
	
		[Description("Diameter of the sheeth (duct) around the tendon, if there is one with this type o" +
	    "f tendon.")]
		public IfcPositiveLengthMeasure? SheathDiameter { get { return this._SheathDiameter; } set { this._SheathDiameter = value;} }
	
	
	}
	
}
