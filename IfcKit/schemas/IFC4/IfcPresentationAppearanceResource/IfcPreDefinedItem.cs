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
	[Guid("24f52902-4123-41ea-bdd0-f47e6ab00191")]
	public abstract partial class IfcPreDefinedItem : IfcPresentationItem
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcLabel _Name;
	
	
		[Description("<EPM-HTML>\r\nThe string by which the pre defined item is identified. Allowable val" +
	    "ues for the string are declared at the level of subtypes.\r\n</EPM-HTML>")]
		public IfcLabel Name { get { return this._Name; } set { this._Name = value;} }
	
	
	}
	
}
