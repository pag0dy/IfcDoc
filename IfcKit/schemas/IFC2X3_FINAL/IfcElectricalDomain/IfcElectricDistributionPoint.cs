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
using BuildingSmart.IFC.IfcSharedBldgServiceElements;
using BuildingSmart.IFC.IfcStructuralAnalysisDomain;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcElectricalDomain
{
	[Guid("839af1db-2fba-4218-b66d-51a6d1ec4eca")]
	public partial class IfcElectricDistributionPoint : IfcFlowController
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcElectricDistributionPointFunctionEnum _DistributionPointFunction;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcLabel? _UserDefinedFunction;
	
	
		public IfcElectricDistributionPoint()
		{
		}
	
		public IfcElectricDistributionPoint(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcObjectPlacement __ObjectPlacement, IfcProductRepresentation __Representation, IfcIdentifier? __Tag, IfcElectricDistributionPointFunctionEnum __DistributionPointFunction, IfcLabel? __UserDefinedFunction)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType, __ObjectPlacement, __Representation, __Tag)
		{
			this._DistributionPointFunction = __DistributionPointFunction;
			this._UserDefinedFunction = __UserDefinedFunction;
		}
	
		[Description("Identifies the functions or purposes that a distribution point may fulfill from w" +
	    "hich that required may be selected.")]
		public IfcElectricDistributionPointFunctionEnum DistributionPointFunction { get { return this._DistributionPointFunction; } set { this._DistributionPointFunction = value;} }
	
		public IfcLabel? UserDefinedFunction { get { return this._UserDefinedFunction; } set { this._UserDefinedFunction = value;} }
	
	
	}
	
}
