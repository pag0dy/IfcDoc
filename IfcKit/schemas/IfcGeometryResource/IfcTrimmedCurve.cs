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

using BuildingSmart.IFC.IfcGeometricConstraintResource;
using BuildingSmart.IFC.IfcGeometricModelResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcGeometryResource
{
	public partial class IfcTrimmedCurve : IfcBoundedCurve
	{
		[DataMember(Order = 0)] 
		[XmlElement]
		[Description("The curve to be trimmed. For curves with multiple representations any parameter values given as Trim1 or Trim2 refer to the master representation of the BasisCurve only.")]
		[Required()]
		public IfcCurve BasisCurve { get; set; }
	
		[DataMember(Order = 1)] 
		[Description("The first trimming point which may be specified as a Cartesian point, as a real parameter or both.")]
		[Required()]
		[MinLength(1)]
		[MaxLength(2)]
		public ISet<IfcTrimmingSelect> Trim1 { get; protected set; }
	
		[DataMember(Order = 2)] 
		[Description("The second trimming point which may be specified as a Cartesian point, as a real parameter or both.")]
		[Required()]
		[MinLength(1)]
		[MaxLength(2)]
		public ISet<IfcTrimmingSelect> Trim2 { get; protected set; }
	
		[DataMember(Order = 3)] 
		[XmlAttribute]
		[Description("Flag to indicate whether the direction of the trimmed curve agrees with or is opposed to the direction of the basis curve.")]
		[Required()]
		public IfcBoolean SenseAgreement { get; set; }
	
		[DataMember(Order = 4)] 
		[XmlAttribute]
		[Description("Where both parameter and point are present at either end of the curve this indicates the preferred form.")]
		[Required()]
		public IfcTrimmingPreference MasterRepresentation { get; set; }
	
	
		public IfcTrimmedCurve(IfcCurve __BasisCurve, IfcTrimmingSelect[] __Trim1, IfcTrimmingSelect[] __Trim2, IfcBoolean __SenseAgreement, IfcTrimmingPreference __MasterRepresentation)
		{
			this.BasisCurve = __BasisCurve;
			this.Trim1 = new HashSet<IfcTrimmingSelect>(__Trim1);
			this.Trim2 = new HashSet<IfcTrimmingSelect>(__Trim2);
			this.SenseAgreement = __SenseAgreement;
			this.MasterRepresentation = __MasterRepresentation;
		}
	
	
	}
	
}
