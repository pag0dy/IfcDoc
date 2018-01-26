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

using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcPresentationAppearanceResource
{
	[Guid("be4e92f1-7f15-46b5-ba75-b48d48f504bb")]
	public partial class IfcStyledItem : IfcRepresentationItem
	{
		[DataMember(Order=0)] 
		IfcRepresentationItem _Item;
	
		[DataMember(Order=1)] 
		[Required()]
		[MinLength(1)]
		ISet<IfcPresentationStyleAssignment> _Styles = new HashSet<IfcPresentationStyleAssignment>();
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcLabel? _Name;
	
	
		public IfcStyledItem()
		{
		}
	
		public IfcStyledItem(IfcRepresentationItem __Item, IfcPresentationStyleAssignment[] __Styles, IfcLabel? __Name)
		{
			this._Item = __Item;
			this._Styles = new HashSet<IfcPresentationStyleAssignment>(__Styles);
			this._Name = __Name;
		}
	
		[Description(@"<EPM-HTML>
	A geometric representation item to which the style is assigned.
	  <blockquote> <font size=""-1"" color=""#0000ff"">
	IFC2x Edition 2 Addendum 2 CHANGE The attribute <i>Item</i> has been made optional. Upward compatibility for file based exchange is guaranteed.
	  </font></blockquote>
	</EPM-HTML>")]
		public IfcRepresentationItem Item { get { return this._Item; } set { this._Item = value;} }
	
		[Description("Representation style assignments which are assigned to an item. NOTE: In current " +
	    "IFC release only one presentation style assignment shall be assigned.")]
		public ISet<IfcPresentationStyleAssignment> Styles { get { return this._Styles; } }
	
		[Description("The word, or group of words, by which the styled item is referred to.")]
		public IfcLabel? Name { get { return this._Name; } set { this._Name = value;} }
	
	
	}
	
}
