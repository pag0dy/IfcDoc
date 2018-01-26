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
using BuildingSmart.IFC.IfcStructuralLoadResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcStructuralAnalysisDomain
{
	[Guid("7709f951-4bb1-47aa-be0f-22476df3f870")]
	public partial class IfcRelConnectsStructuralMember : IfcRelConnects
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcStructuralMember _RelatingStructuralMember;
	
		[DataMember(Order=1)] 
		[Required()]
		IfcStructuralConnection _RelatedStructuralConnection;
	
		[DataMember(Order=2)] 
		IfcBoundaryCondition _AppliedCondition;
	
		[DataMember(Order=3)] 
		IfcStructuralConnectionCondition _AdditionalConditions;
	
		[DataMember(Order=4)] 
		[XmlAttribute]
		IfcLengthMeasure? _SupportedLength;
	
		[DataMember(Order=5)] 
		IfcAxis2Placement3D _ConditionCoordinateSystem;
	
	
		public IfcRelConnectsStructuralMember()
		{
		}
	
		public IfcRelConnectsStructuralMember(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcStructuralMember __RelatingStructuralMember, IfcStructuralConnection __RelatedStructuralConnection, IfcBoundaryCondition __AppliedCondition, IfcStructuralConnectionCondition __AdditionalConditions, IfcLengthMeasure? __SupportedLength, IfcAxis2Placement3D __ConditionCoordinateSystem)
			: base(__GlobalId, __OwnerHistory, __Name, __Description)
		{
			this._RelatingStructuralMember = __RelatingStructuralMember;
			this._RelatedStructuralConnection = __RelatedStructuralConnection;
			this._AppliedCondition = __AppliedCondition;
			this._AdditionalConditions = __AdditionalConditions;
			this._SupportedLength = __SupportedLength;
			this._ConditionCoordinateSystem = __ConditionCoordinateSystem;
		}
	
		[Description("Reference to an instance of IfcStructuralMember (or its subclasses) which is conn" +
	    "ected to the specified structural connection. ")]
		public IfcStructuralMember RelatingStructuralMember { get { return this._RelatingStructuralMember; } set { this._RelatingStructuralMember = value;} }
	
		[Description("Reference to an instance of IfcStructuralConnection (or its subclasses) which is " +
	    "connected to the specified structural member.")]
		public IfcStructuralConnection RelatedStructuralConnection { get { return this._RelatedStructuralConnection; } set { this._RelatedStructuralConnection = value;} }
	
		[Description(@"<EPM-HTML>Reference to an instance of <i>IfcBoundaryCondition</i> which is used to define the connections properties.
	  <blockquote> <font size=""-1"">
	NOTE&nbsp; The boundary condition applied to a member-connection-relationship is also called ""release""</font></blockquote>
	</EPM-HTML>")]
		public IfcBoundaryCondition AppliedCondition { get { return this._AppliedCondition; } set { this._AppliedCondition = value;} }
	
		[Description("Reference to instances describing additional connection properties.")]
		public IfcStructuralConnectionCondition AdditionalConditions { get { return this._AdditionalConditions; } set { this._AdditionalConditions = value;} }
	
		[Description("Defines the \'supported length\' of this structural connection. See Fig. for more d" +
	    "etail. ")]
		public IfcLengthMeasure? SupportedLength { get { return this._SupportedLength; } set { this._SupportedLength = value;} }
	
		[Description("Defines a new coordinate system used for the description of the connection proper" +
	    "ties. The usage of this coordinate system is described more detailed in the defi" +
	    "nition of the subtypes of this entity definition.")]
		public IfcAxis2Placement3D ConditionCoordinateSystem { get { return this._ConditionCoordinateSystem; } set { this._ConditionCoordinateSystem = value;} }
	
	
	}
	
}
