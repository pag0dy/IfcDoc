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

namespace BuildingSmart.IFC.IfcPropertyResource
{
	public partial class IfcComplexProperty : IfcProperty
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("<EPM-HTML>Usage description of the <I>IfcComplexProperty</I> within the property set which references the <I>IfcComplexProperty</I>.  <BLOCKQUOTE> <FONT SIZE=\"-1\">NOTE: Consider a complex property for glazing properties. The <I>Name</I> attribute of the <I>IfcComplexProperty</I> could be <I>Pset_GlazingProperties</I>, and the UsageName attribute could be <I>OuterGlazingPane</I>.</FONT></BLOCKQUOTE>  </EPM-HTML>  ")]
		[Required()]
		public IfcIdentifier UsageName { get; set; }
	
		[DataMember(Order = 1)] 
		[Description("Set of properties that can be used within this complex property (may include other complex properties).")]
		[Required()]
		[MinLength(1)]
		public ISet<IfcProperty> HasProperties { get; protected set; }
	
	
		public IfcComplexProperty(IfcIdentifier __Name, IfcText? __Description, IfcIdentifier __UsageName, IfcProperty[] __HasProperties)
			: base(__Name, __Description)
		{
			this.UsageName = __UsageName;
			this.HasProperties = new HashSet<IfcProperty>(__HasProperties);
		}
	
	
	}
	
}
