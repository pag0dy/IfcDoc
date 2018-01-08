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
	[Guid("6598c933-b905-44ea-8878-9e20fd96c12d")]
	public abstract partial class IfcStructuralMember : IfcStructuralItem
	{
		[InverseProperty("RelatedStructuralMember")] 
		ISet<IfcRelConnectsStructuralElement> _ReferencesElement = new HashSet<IfcRelConnectsStructuralElement>();
	
		[InverseProperty("RelatingStructuralMember")] 
		ISet<IfcRelConnectsStructuralMember> _ConnectedBy = new HashSet<IfcRelConnectsStructuralMember>();
	
	
		[Description("<EPM-HTML>\r\nInverse link to the relationship object, that connects a physical ele" +
	    "ment to this structural member (the element of which this structural member is t" +
	    "he analytical idealization).\r\n</EPM-HTML>")]
		public ISet<IfcRelConnectsStructuralElement> ReferencesElement { get { return this._ReferencesElement; } }
	
		[Description("Inverse relationship to all structural connections (i.e. to supports or connectin" +
	    "g elements) which are defined for this structural member.")]
		public ISet<IfcRelConnectsStructuralMember> ConnectedBy { get { return this._ConnectedBy; } }
	
	
	}
	
}
