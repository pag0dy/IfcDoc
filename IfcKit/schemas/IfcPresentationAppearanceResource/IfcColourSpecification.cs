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

using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationDefinitionResource;

namespace BuildingSmart.IFC.IfcPresentationAppearanceResource
{
	public abstract partial class IfcColourSpecification : IfcPresentationItem,
		BuildingSmart.IFC.IfcPresentationAppearanceResource.IfcColour
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Optional name given to a particular colour specification in addition to the colour components (like the RGB values).  <blockquote class=\"example\">EXAMPLE&nbsp; Names of a industry colour classification, such as RAL.</blockquote>  <blockquote class=\"change-ifc2x3\">IFC2x3 CHANGE&nbsp; Attribute added.</blockquote>")]
		public IfcLabel? Name { get; set; }
	
	
		protected IfcColourSpecification(IfcLabel? __Name)
		{
			this.Name = __Name;
		}
	
	
	}
	
}
