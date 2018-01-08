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

using BuildingSmart.IFC.IfcActorResource;
using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcGeometricConstraintResource;
using BuildingSmart.IFC.IfcGeometricModelResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcProcessExtension;
using BuildingSmart.IFC.IfcPropertyResource;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcKernel
{
	[Guid("dfa52a71-6e64-4b4c-af07-d476c558c888")]
	public abstract partial class IfcPropertyTemplate : IfcPropertyTemplateDefinition
	{
		[InverseProperty("HasPropertyTemplates")] 
		ISet<IfcComplexPropertyTemplate> _PartOfComplexTemplate = new HashSet<IfcComplexPropertyTemplate>();
	
		[InverseProperty("HasPropertyTemplates")] 
		ISet<IfcPropertySetTemplate> _PartOfPsetTemplate = new HashSet<IfcPropertySetTemplate>();
	
	
		[Description("<EPM-HTML>\r\nReference to a complex property templates. It should only be provided" +
	    ", if the <em>PropertyType</em> of the referenced complex property template is se" +
	    "t to <small>COMPLEX</small>.\r\n</EPM-HTML>")]
		public ISet<IfcComplexPropertyTemplate> PartOfComplexTemplate { get { return this._PartOfComplexTemplate; } }
	
		[Description(@"<EPM-HTML>
	Reference to the <em>IfcPropertySetTemplate</em> that defines the scope for the <em>IfcPropertyTemplate</em>. A single <em>IfcPropertyTemplate</em> can be defined within the scope of zero, one or many <em>IfcPropertySetTemplate</em>'.
	</EPM-HTML>")]
		public ISet<IfcPropertySetTemplate> PartOfPsetTemplate { get { return this._PartOfPsetTemplate; } }
	
	
	}
	
}
