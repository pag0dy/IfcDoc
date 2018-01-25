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
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcProductExtension;
using BuildingSmart.IFC.IfcProfilePropertyResource;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcStructuralLoadResource;

namespace BuildingSmart.IFC.IfcStructuralAnalysisDomain
{
	[Guid("d51c7f76-137f-4445-9406-c987d9f4cf65")]
	public abstract partial class IfcStructuralConnection : IfcStructuralItem
	{
		[DataMember(Order=0)] 
		IfcBoundaryCondition _AppliedCondition;
	
		[InverseProperty("RelatedStructuralConnection")] 
		ISet<IfcRelConnectsStructuralMember> _ConnectsStructuralMembers = new HashSet<IfcRelConnectsStructuralMember>();
	
	
		[Description("Optional reference to an instance of IfcBoundaryCondition which defines the suppo" +
	    "rt condition of this \'connection\'.")]
		public IfcBoundaryCondition AppliedCondition { get { return this._AppliedCondition; } set { this._AppliedCondition = value;} }
	
		[Description("References to the IfcRelConnectsStructuralMembers relationship by which structura" +
	    "l members can be associated to structural connections.")]
		public ISet<IfcRelConnectsStructuralMember> ConnectsStructuralMembers { get { return this._ConnectsStructuralMembers; } }
	
	
	}
	
}
