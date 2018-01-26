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

namespace BuildingSmart.IFC.IfcPresentationAppearanceResource
{
	[Guid("ab926025-a25c-40a8-9608-000b0b34210c")]
	public abstract partial class IfcPresentationStyle :
		BuildingSmart.IFC.IfcPresentationAppearanceResource.IfcStyleAssignmentSelect
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcLabel? _Name;
	
	
		public IfcPresentationStyle()
		{
		}
	
		public IfcPresentationStyle(IfcLabel? __Name)
		{
			this._Name = __Name;
		}
	
		[Description("Name of the presentation style.")]
		public IfcLabel? Name { get { return this._Name; } set { this._Name = value;} }
	
	
	}
	
}
