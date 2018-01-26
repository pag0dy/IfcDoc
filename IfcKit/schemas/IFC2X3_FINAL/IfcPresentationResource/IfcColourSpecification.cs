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

using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcPresentationResource
{
	[Guid("1dd034d3-b72f-45e1-8aff-059b6baa42d1")]
	public abstract partial class IfcColourSpecification :
		BuildingSmart.IFC.IfcPresentationResource.IfcColour
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcLabel? _Name;
	
	
		public IfcColourSpecification()
		{
		}
	
		public IfcColourSpecification(IfcLabel? __Name)
		{
			this._Name = __Name;
		}
	
		[Description(@"<EPM-HTML>
	Optional name given to a particular colour specification in addition to the colour components (like the RGB values).
	<blockquote><small>
	  NOTE&nbsp; Examples are the names of a industry colour classification, such as RAL.<br>
	<font color=""#FF0000"">IFC2x Edition 3 CHANGE&nbsp; Attribute added.
	</font></small></blockquote>
	</EPM-HTML>")]
		public IfcLabel? Name { get { return this._Name; } set { this._Name = value;} }
	
	
	}
	
}
