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

using BuildingSmart.IFC.IfcGeometricConstraintResource;
using BuildingSmart.IFC.IfcGeometricModelResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcGeometryResource
{
	[Guid("30ab14e9-5a59-453a-9a02-815cbd5e2f4f")]
	public partial class IfcTrimmedCurve : IfcBoundedCurve
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcCurve _BasisCurve;
	
		[DataMember(Order=1)] 
		[Required()]
		[MinLength(1)]
		[MaxLength(2)]
		ISet<IfcTrimmingSelect> _Trim1 = new HashSet<IfcTrimmingSelect>();
	
		[DataMember(Order=2)] 
		[Required()]
		[MinLength(1)]
		[MaxLength(2)]
		ISet<IfcTrimmingSelect> _Trim2 = new HashSet<IfcTrimmingSelect>();
	
		[DataMember(Order=3)] 
		[Required()]
		Boolean _SenseAgreement;
	
		[DataMember(Order=4)] 
		[XmlAttribute]
		[Required()]
		IfcTrimmingPreference _MasterRepresentation;
	
	
		public IfcTrimmedCurve()
		{
		}
	
		public IfcTrimmedCurve(IfcCurve __BasisCurve, IfcTrimmingSelect[] __Trim1, IfcTrimmingSelect[] __Trim2, Boolean __SenseAgreement, IfcTrimmingPreference __MasterRepresentation)
		{
			this._BasisCurve = __BasisCurve;
			this._Trim1 = new HashSet<IfcTrimmingSelect>(__Trim1);
			this._Trim2 = new HashSet<IfcTrimmingSelect>(__Trim2);
			this._SenseAgreement = __SenseAgreement;
			this._MasterRepresentation = __MasterRepresentation;
		}
	
		[Description("The curve to be trimmed. For curves with multiple representations any parameter v" +
	    "alues given as Trim1 or Trim2 refer to the master representation of the BasisCur" +
	    "ve only.")]
		public IfcCurve BasisCurve { get { return this._BasisCurve; } set { this._BasisCurve = value;} }
	
		[Description("The first trimming point which may be specified as a Cartesian point, as a real p" +
	    "arameter or both.")]
		public ISet<IfcTrimmingSelect> Trim1 { get { return this._Trim1; } }
	
		[Description("The second trimming point which may be specified as a Cartesian point, as a real " +
	    "parameter or both.")]
		public ISet<IfcTrimmingSelect> Trim2 { get { return this._Trim2; } }
	
		[Description("Flag to indicate whether the direction of the trimmed curve agrees with or is opp" +
	    "osed to the direction of the basis curve.")]
		public Boolean SenseAgreement { get { return this._SenseAgreement; } set { this._SenseAgreement = value;} }
	
		[Description("Where both parameter and point are present at either end of the curve this indica" +
	    "tes the preferred form.")]
		public IfcTrimmingPreference MasterRepresentation { get { return this._MasterRepresentation; } set { this._MasterRepresentation = value;} }
	
	
	}
	
}
