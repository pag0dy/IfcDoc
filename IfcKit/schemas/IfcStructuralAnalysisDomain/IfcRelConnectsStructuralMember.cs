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

using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcStructuralLoadResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcStructuralAnalysisDomain
{
	public partial class IfcRelConnectsStructuralMember : IfcRelConnects
	{
		[DataMember(Order = 0)] 
		[XmlElement]
		[Description("Reference to an instance of IfcStructuralMember (or its subclasses) which is connected to the specified structural connection. ")]
		[Required()]
		public IfcStructuralMember RelatingStructuralMember { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlElement]
		[Description("Reference to an instance of IfcStructuralConnection (or its subclasses) which is connected to the specified structural member.")]
		[Required()]
		public IfcStructuralConnection RelatedStructuralConnection { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlElement]
		[Description("Conditions which define the connections properties.  Connection conditions are often called &quot;release&quot; but are not only used to define mechanisms like hinges but also rigid, elastic, and other conditions.")]
		public IfcBoundaryCondition AppliedCondition { get; set; }
	
		[DataMember(Order = 3)] 
		[XmlElement]
		[Description("Describes additional connection properties.")]
		public IfcStructuralConnectionCondition AdditionalConditions { get; set; }
	
		[DataMember(Order = 4)] 
		[XmlAttribute]
		[Description("Defines the 'supported length' of this structural connection. See Fig. for more detail. ")]
		public IfcLengthMeasure? SupportedLength { get; set; }
	
		[DataMember(Order = 5)] 
		[XmlElement]
		[Description("Defines a coordinate system used for the description of the connection properties in <em>ConnectionCondition</em> relative to the local coordinate system of <em>RelatingStructuralMember</em>.  If left unspecified, the placement <em>IfcAxis2Placement3D</em>((x,y,z), ?, ?) is implied with x,y,z being the local member coordinates where the connection is made and the default axes directions being in parallel with the local axes of <em>RelatingStructuralMember</em>.")]
		public IfcAxis2Placement3D ConditionCoordinateSystem { get; set; }
	
	
		public IfcRelConnectsStructuralMember(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcStructuralMember __RelatingStructuralMember, IfcStructuralConnection __RelatedStructuralConnection, IfcBoundaryCondition __AppliedCondition, IfcStructuralConnectionCondition __AdditionalConditions, IfcLengthMeasure? __SupportedLength, IfcAxis2Placement3D __ConditionCoordinateSystem)
			: base(__GlobalId, __OwnerHistory, __Name, __Description)
		{
			this.RelatingStructuralMember = __RelatingStructuralMember;
			this.RelatedStructuralConnection = __RelatedStructuralConnection;
			this.AppliedCondition = __AppliedCondition;
			this.AdditionalConditions = __AdditionalConditions;
			this.SupportedLength = __SupportedLength;
			this.ConditionCoordinateSystem = __ConditionCoordinateSystem;
		}
	
	
	}
	
}
