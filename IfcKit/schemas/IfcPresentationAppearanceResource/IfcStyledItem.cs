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
		[XmlIgnore]
		[Description("A geometric representation item to which the style is assigned.    <blockquote class=\"change-ifc2x2\">IFC2x2 Add2 CHANGE The attribute <em>Item</em> has been made optional. Upward compatibility for file based exchange is guaranteed.</blockquote>")]
		public IfcRepresentationItem Item { get; set; }
	
		[DataMember(Order = 1)] 
		[Description("Representation styles which are assigned, either to an geometric representation item, or to a material definition.  <blockquote class=\"change-ifc2x4\">IFC4 CHANGE  The data type has been changed to <em>IfcStyleAssignmentSelect</em> with upward compatibility   for file based exchange.</blockquote>    <blockquote class=\"note\">NOTE&nbsp; Only the select item <em>IfcPresentationStyle</em> shall be used from IFC4 onwards, the <em>IfcPresentationStyleAssignment</em> has been deprecated.</blockquote> ")]
		[Required()]
		[MinLength(1)]
		public ISet<IfcStyleAssignmentSelect> Styles { get; protected set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("The word, or group of words, by which the styled item is referred to.")]
		public IfcLabel? Name { get; set; }
	
	
		public IfcStyledItem(IfcRepresentationItem __Item, IfcStyleAssignmentSelect[] __Styles, IfcLabel? __Name)
		{
			this.Item = __Item;
			this.Styles = new HashSet<IfcStyleAssignmentSelect>(__Styles);
			this.Name = __Name;
		}
	
	
	}
	
}
