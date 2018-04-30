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


namespace BuildingSmart.IFC.IfcPresentationAppearanceResource
{
	public partial class IfcPresentationStyleAssignment :
		BuildingSmart.IFC.IfcPresentationAppearanceResource.IfcStyleAssignmentSelect
	{
		[DataMember(Order = 0)] 
		[Description("A set of presentation styles that are assigned to styled items.")]
		[Required()]
		[MinLength(1)]
		public ISet<IfcPresentationStyleSelect> Styles { get; protected set; }
	
	
		public IfcPresentationStyleAssignment(IfcPresentationStyleSelect[] __Styles)
		{
			this.Styles = new HashSet<IfcPresentationStyleSelect>(__Styles);
		}
	
	
	}
	
}
