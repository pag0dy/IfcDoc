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
		[Description("Reference to an instance of IfcStructuralMember (or its subclasses) which is connected to the specified structural connection. ")]
		[Required()]
		public IfcStructuralMember RelatingStructuralMember { get; set; }
	
		[DataMember(Order = 1)] 
		[Description("Reference to an instance of IfcStructuralConnection (or its subclasses) which is connected to the specified structural member.")]
		[Required()]
		public IfcStructuralConnection RelatedStructuralConnection { get; set; }
	
		[DataMember(Order = 2)] 
		[Description("<EPM-HTML>Reference to an instance of <i>IfcBoundaryCondition</i> which is used to define the connections properties.    <blockquote> <font size=\"-1\">  NOTE&nbsp; The boundary condition applied to a member-connection-relationship is also called \"release\"</font></blockquote>  </EPM-HTML>")]
		public IfcBoundaryCondition AppliedCondition { get; set; }
	
		[DataMember(Order = 3)] 
		[Description("Reference to instances describing additional connection properties.")]
		public IfcStructuralConnectionCondition AdditionalConditions { get; set; }
	
		[DataMember(Order = 4)] 
		[XmlAttribute]
		[Description("Defines the 'supported length' of this structural connection. See Fig. for more detail. ")]
		public IfcLengthMeasure? SupportedLength { get; set; }
	
		[DataMember(Order = 5)] 
		[Description("Defines a new coordinate system used for the description of the connection properties. The usage of this coordinate system is described more detailed in the definition of the subtypes of this entity definition.")]
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
