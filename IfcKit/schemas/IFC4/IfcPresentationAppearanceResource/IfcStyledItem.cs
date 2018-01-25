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

using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcGeometricModelResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationDefinitionResource;
using BuildingSmart.IFC.IfcTopologyResource;

namespace BuildingSmart.IFC.IfcPresentationAppearanceResource
{
	[Guid("03067245-b9da-400b-8de8-c6189fa9b928")]
	public partial class IfcStyledItem : IfcRepresentationItem
	{
		[DataMember(Order=0)] 
		[XmlIgnore]
		IfcRepresentationItem _Item;
	
		[DataMember(Order=1)] 
		[Required()]
		ISet<IfcStyleAssignmentSelect> _Styles = new HashSet<IfcStyleAssignmentSelect>();
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcLabel? _Name;
	
	
		[Description("A geometric representation item to which the style is assigned.\r\n  <blockquote cl" +
	    "ass=\"change-ifc2x2\">IFC2x2 Add2 CHANGE The attribute <em>Item</em> has been made" +
	    " optional. Upward compatibility for file based exchange is guaranteed.</blockquo" +
	    "te>")]
		public IfcRepresentationItem Item { get { return this._Item; } set { this._Item = value;} }
	
		[Description(@"Representation styles which are assigned, either to an geometric representation item, or to a material definition.
	<blockquote class=""change-ifc2x4"">IFC4 CHANGE  The data type has been changed to <em>IfcStyleAssignmentSelect</em> with upward compatibility 
	for file based exchange.</blockquote>
	  <blockquote class=""note"">NOTE&nbsp; Only the select item <em>IfcPresentationStyle</em> shall be used from IFC4 onwards, the <em>IfcPresentationStyleAssignment</em> has been deprecated.</blockquote> ")]
		public ISet<IfcStyleAssignmentSelect> Styles { get { return this._Styles; } }
	
		[Description("The word, or group of words, by which the styled item is referred to.")]
		public IfcLabel? Name { get { return this._Name; } set { this._Name = value;} }
	
	
	}
	
}
