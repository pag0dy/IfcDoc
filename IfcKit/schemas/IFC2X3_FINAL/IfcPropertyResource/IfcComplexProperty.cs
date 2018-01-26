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

namespace BuildingSmart.IFC.IfcPropertyResource
{
	[Guid("a9e45d96-3e40-4160-b12e-12f62f8f869e")]
	public partial class IfcComplexProperty : IfcProperty
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcIdentifier _UsageName;
	
		[DataMember(Order=1)] 
		[Required()]
		[MinLength(1)]
		ISet<IfcProperty> _HasProperties = new HashSet<IfcProperty>();
	
	
		public IfcComplexProperty()
		{
		}
	
		public IfcComplexProperty(IfcIdentifier __Name, IfcText? __Description, IfcIdentifier __UsageName, IfcProperty[] __HasProperties)
			: base(__Name, __Description)
		{
			this._UsageName = __UsageName;
			this._HasProperties = new HashSet<IfcProperty>(__HasProperties);
		}
	
		[Description(@"<EPM-HTML>Usage description of the <I>IfcComplexProperty</I> within the property set which references the <I>IfcComplexProperty</I>.
	<BLOCKQUOTE> <FONT SIZE=""-1"">NOTE: Consider a complex property for glazing properties. The <I>Name</I> attribute of the <I>IfcComplexProperty</I> could be <I>Pset_GlazingProperties</I>, and the UsageName attribute could be <I>OuterGlazingPane</I>.</FONT></BLOCKQUOTE>
	</EPM-HTML>
	")]
		public IfcIdentifier UsageName { get { return this._UsageName; } set { this._UsageName = value;} }
	
		[Description("Set of properties that can be used within this complex property (may include othe" +
	    "r complex properties).")]
		public ISet<IfcProperty> HasProperties { get { return this._HasProperties; } }
	
	
	}
	
}
