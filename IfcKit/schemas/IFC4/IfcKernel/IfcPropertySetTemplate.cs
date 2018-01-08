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
	[Guid("a7b77ff0-78ea-4751-af7d-edca24e4a5db")]
	public partial class IfcPropertySetTemplate : IfcPropertyTemplateDefinition
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcPropertySetTemplateTypeEnum? _TemplateType;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcIdentifier? _ApplicableEntity;
	
		[DataMember(Order=2)] 
		[Required()]
		ISet<IfcPropertyTemplate> _HasPropertyTemplates = new HashSet<IfcPropertyTemplate>();
	
		[InverseProperty("RelatingTemplate")] 
		ISet<IfcRelDefinesByTemplate> _Defines = new HashSet<IfcRelDefinesByTemplate>();
	
	
		[Description(@"<EPM-HTML>
	Property set type defining whether the property set is applicable to a type (subtypes of <em>IfcTypeObject</em>), to an occurrence (subtypes of <em>IfcObject</em>), or as a special case to a performance history.<br><br>
	The attribute <em>ApplicableEntity</em> may further refine the applicability to a single or multiple entity type(s).
	</EPM-HTML>")]
		public IfcPropertySetTemplateTypeEnum? TemplateType { get { return this._TemplateType; } set { this._TemplateType = value;} }
	
		[Description("<EPM-HTML>\r\nThe attribute optionally defines the data type of the applicable type" +
	    " or occurrence object, to which the assigned property set template can relate. I" +
	    "f not present, no instruction is given to which type or occurrence object the pr" +
	    "operty set template is applicable. The following conventions are used:\r\n<ul>\r\n  " +
	    "<li>The IFC entity name of the applicable entity using the IFC naming convention" +
	    ", CamelCase with IFC prefix</li>\r\n  <li>It can be optionally followed by the pre" +
	    "defined type after the separator \"/\" (forward slash), using upper case</li>\r\n  <" +
	    "li>If a performance history object of a particular distribution object is attrib" +
	    "utes by the property set template, then the entity name (and potentially amended" +
	    " by the predefined type) is expanded by adding \'[PerformanceHistory]\'\r\n  <li>If " +
	    "one property set template is applicable to many type and/or occurrence objects, " +
	    "then those object names should be separate by comma \",\" forming a comma separate" +
	    "d string.\r\n</ul>\r\n<blockquote class=\"example\">EXAMPLE  Refering to a boiler type" +
	    " as applicable entity would be expressed as \'IfcBoilerType\', refering to a steam" +
	    " boiler type as applicable entity would be expressed as \'IfcBoilerType/STEAM\', r" +
	    "efering to a wall and wall standard case and a wall type would be expressed as \'" +
	    "IfcWall, IfcWallStandardCase, IfcWallType\'. An applicable <em>IfcPerformanceHist" +
	    "ory</em> assigned to an occurrence or type object would be indicated by IfcBoile" +
	    "rType[PerformanceHistory], or respectively IfcBoilerType/STEAM[PerformanceHistor" +
	    "y].</blockquote>\r\n</EPM-HTML>")]
		public IfcIdentifier? ApplicableEntity { get { return this._ApplicableEntity; } set { this._ApplicableEntity = value;} }
	
		[Description("<EPM-HTML>\r\nSet of <em>IfcPropertyTemplate</em>\'s that are defined within the sco" +
	    "pe of the <em>IfcPropertySetTemplate</em>.\r\n</EPM-HTML>")]
		public ISet<IfcPropertyTemplate> HasPropertyTemplates { get { return this._HasPropertyTemplates; } }
	
		[Description("<EPM-HTML>\r\nRelation to the property sets, via the objectified relationship <em>I" +
	    "fcRelDefinesByTemplate</em>, that, if given, utilize the definition template. \r\n" +
	    "</EPM-HTML>")]
		public ISet<IfcRelDefinesByTemplate> Defines { get { return this._Defines; } }
	
	
	}
	
}
