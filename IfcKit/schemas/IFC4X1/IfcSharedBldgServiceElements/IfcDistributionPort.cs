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
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcSharedBldgServiceElements
{
	[Guid("1b957306-e396-43ea-b6ee-e7e28d37f9e9")]
	public partial class IfcDistributionPort : IfcPort
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcFlowDirectionEnum? _FlowDirection;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcDistributionPortTypeEnum? _PredefinedType;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcDistributionSystemEnum? _SystemType;
	
	
		public IfcDistributionPort()
		{
		}
	
		public IfcDistributionPort(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcObjectPlacement __ObjectPlacement, IfcProductRepresentation __Representation, IfcFlowDirectionEnum? __FlowDirection, IfcDistributionPortTypeEnum? __PredefinedType, IfcDistributionSystemEnum? __SystemType)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType, __ObjectPlacement, __Representation)
		{
			this._FlowDirection = __FlowDirection;
			this._PredefinedType = __PredefinedType;
			this._SystemType = __SystemType;
		}
	
		[Description("Enumeration that identifies if this port is a Sink (inlet), a Source (outlet) or " +
	    "both a SinkAndSource.\r\n")]
		public IfcFlowDirectionEnum? FlowDirection { get { return this._FlowDirection; } set { this._FlowDirection = value;} }
	
		public IfcDistributionPortTypeEnum? PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
		[Description("Enumeration that identifies the system type.  If a system type is defined, the po" +
	    "rt may only be connected to other ports having the same system type.")]
		public IfcDistributionSystemEnum? SystemType { get { return this._SystemType; } set { this._SystemType = value;} }
	
	
	}
	
}
