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

namespace BuildingSmart.IFC.IfcExternalReferenceResource
{
	public partial class IfcClassificationNotationFacet
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("The notation value that specifies the classification e.g. 'L781'")]
		[Required()]
		public IfcLabel NotationValue { get; set; }
	
	
		public IfcClassificationNotationFacet(IfcLabel __NotationValue)
		{
			this.NotationValue = __NotationValue;
		}
	
	
	}
	
}
