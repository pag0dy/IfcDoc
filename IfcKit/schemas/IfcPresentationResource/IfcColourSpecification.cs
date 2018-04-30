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

namespace BuildingSmart.IFC.IfcPresentationResource
{
	public abstract partial class IfcColourSpecification :
		BuildingSmart.IFC.IfcPresentationResource.IfcColour
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("<EPM-HTML>  Optional name given to a particular colour specification in addition to the colour components (like the RGB values).  <blockquote><small>    NOTE&nbsp; Examples are the names of a industry colour classification, such as RAL.<br>  <font color=\"#FF0000\">IFC2x Edition 3 CHANGE&nbsp; Attribute added.  </font></small></blockquote>  </EPM-HTML>")]
		public IfcLabel? Name { get; set; }
	
	
		protected IfcColourSpecification(IfcLabel? __Name)
		{
			this.Name = __Name;
		}
	
	
	}
	
}
