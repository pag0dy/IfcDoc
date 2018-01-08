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
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcProductExtension;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcStructuralLoadResource;

namespace BuildingSmart.IFC.IfcStructuralAnalysisDomain
{
	[Guid("a3f65142-e263-40a0-a199-116ed79dd647")]
	public partial class IfcRelConnectsStructuralMember : IfcRelConnects
	{
		[DataMember(Order=0)] 
		[XmlElement("IfcStructuralMember")]
		[Required()]
		IfcStructuralMember _RelatingStructuralMember;
	
		[DataMember(Order=1)] 
		[XmlElement("IfcStructuralConnection")]
		[Required()]
		IfcStructuralConnection _RelatedStructuralConnection;
	
		[DataMember(Order=2)] 
		[XmlElement("IfcBoundaryCondition")]
		IfcBoundaryCondition _AppliedCondition;
	
		[DataMember(Order=3)] 
		[XmlElement("IfcStructuralConnectionCondition")]
		IfcStructuralConnectionCondition _AdditionalConditions;
	
		[DataMember(Order=4)] 
		[XmlAttribute]
		IfcLengthMeasure? _SupportedLength;
	
		[DataMember(Order=5)] 
		[XmlElement("IfcAxis2Placement3D")]
		IfcAxis2Placement3D _ConditionCoordinateSystem;
	
	
		[Description("Reference to an instance of IfcStructuralMember (or its subclasses) which is conn" +
	    "ected to the specified structural connection. ")]
		public IfcStructuralMember RelatingStructuralMember { get { return this._RelatingStructuralMember; } set { this._RelatingStructuralMember = value;} }
	
		[Description("Reference to an instance of IfcStructuralConnection (or its subclasses) which is " +
	    "connected to the specified structural member.")]
		public IfcStructuralConnection RelatedStructuralConnection { get { return this._RelatedStructuralConnection; } set { this._RelatedStructuralConnection = value;} }
	
		[Description("Conditions which define the connections properties.  Connection conditions are of" +
	    "ten called &quot;release&quot; but are not only used to define mechanisms like h" +
	    "inges but also rigid, elastic, and other conditions.")]
		public IfcBoundaryCondition AppliedCondition { get { return this._AppliedCondition; } set { this._AppliedCondition = value;} }
	
		[Description("Describes additional connection properties.")]
		public IfcStructuralConnectionCondition AdditionalConditions { get { return this._AdditionalConditions; } set { this._AdditionalConditions = value;} }
	
		[Description("Defines the \'supported length\' of this structural connection. See Fig. for more d" +
	    "etail. ")]
		public IfcLengthMeasure? SupportedLength { get { return this._SupportedLength; } set { this._SupportedLength = value;} }
	
		[Description(@"Defines a coordinate system used for the description of the connection properties in <em>ConnectionCondition</em> relative to the local coordinate system of <em>RelatingStructuralMember</em>.  If left unspecified, the placement <em>IfcAxis2Placement3D</em>((x,y,z), ?, ?) is implied with x,y,z being the local member coordinates where the connection is made and the default axes directions being in parallel with the local axes of <em>RelatingStructuralMember</em>.")]
		public IfcAxis2Placement3D ConditionCoordinateSystem { get { return this._ConditionCoordinateSystem; } set { this._ConditionCoordinateSystem = value;} }
	
	
	}
	
}
