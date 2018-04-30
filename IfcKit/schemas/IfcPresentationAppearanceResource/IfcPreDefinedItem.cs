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
	public abstract partial class IfcPreDefinedItem : IfcPresentationItem
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("The string by which the pre defined item is identified. Allowable values for the string are declared at the level of subtypes.")]
		[Required()]
		public IfcLabel Name { get; set; }
	
	
		protected IfcPreDefinedItem(IfcLabel __Name)
		{
			this.Name = __Name;
		}
	
	
	}
	
}
