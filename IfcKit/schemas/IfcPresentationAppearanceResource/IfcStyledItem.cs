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
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcPresentationAppearanceResource
{
	public partial class IfcStyledItem : IfcRepresentationItem
	{
		[DataMember(Order = 0)] 
		[Description("<EPM-HTML>  A geometric representation item to which the style is assigned.    <blockquote> <font size=\"-1\" color=\"#0000ff\">  IFC2x Edition 2 Addendum 2 CHANGE The attribute <i>Item</i> has been made optional. Upward compatibility for file based exchange is guaranteed.    </font></blockquote>  </EPM-HTML>")]
		public IfcRepresentationItem Item { get; set; }
	
		[DataMember(Order = 1)] 
		[Description("Representation style assignments which are assigned to an item. NOTE: In current IFC release only one presentation style assignment shall be assigned.")]
		[Required()]
		[MinLength(1)]
		public ISet<IfcPresentationStyleAssignment> Styles { get; protected set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("The word, or group of words, by which the styled item is referred to.")]
		public IfcLabel? Name { get; set; }
	
	
		public IfcStyledItem(IfcRepresentationItem __Item, IfcPresentationStyleAssignment[] __Styles, IfcLabel? __Name)
		{
			this.Item = __Item;
			this.Styles = new HashSet<IfcPresentationStyleAssignment>(__Styles);
			this.Name = __Name;
		}
	
	
	}
	
}
