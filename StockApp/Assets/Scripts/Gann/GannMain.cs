using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GannMain : MonoBehaviour {


	private int[] numberList = new int[] {
        463,464 ,465 ,466, 467 ,468, 469, 470 ,471 ,472 ,473 ,474 ,475 ,476 ,477 ,478 ,479 ,480 ,481 ,482 ,483 ,484, 485,
        462,381 ,382 ,383, 384 ,385, 386, 387 ,388 ,389 ,390 ,391 ,392 ,393 ,394 ,395 ,396 ,397 ,398 ,399 ,400 ,401, 486,
        461,380 ,307 ,308, 309 ,310, 311, 312 ,313 ,314 ,315 ,316 ,317 ,318 ,319 ,320 ,321 ,322 ,323 ,324 ,325 ,402, 487,
        460,379 ,306 ,241, 242 ,243, 244, 245 ,246 ,247 ,248 ,249 ,250 ,251 ,252 ,253 ,254 ,255 ,256 ,257 ,326 ,403, 488,
        459,378 ,305 ,240, 183 ,184, 185, 186 ,187 ,188 ,189 ,190 ,191 ,192 ,193 ,194 ,195 ,196 ,197 ,258 ,327 ,404, 489,
        458,377 ,304 ,239, 182 ,133, 134, 135 ,136 ,137 ,138 ,139 ,140 ,141 ,142 ,143 ,144 ,145 ,198 ,259 ,328 ,405, 490,
        457,376 ,303 ,238, 181 ,132, 91  , 92  ,93   ,94   ,95   ,96   ,97  ,98   ,99   ,100 ,101 ,146 ,199 ,260 ,329 ,406, 491,
        456,375 ,302 ,237, 180 ,131, 90  , 57  ,58   ,59   ,60   ,61   ,62  ,63   ,64   ,65  ,102 ,147 ,200 ,261 ,330 ,407  ,492,
        455,374 ,301 ,236, 179 ,130, 89  , 56  ,31   ,32   ,33   ,34   ,35  ,36   ,37   ,66  ,103 ,148 ,201 ,262 ,331 ,408  ,493,
        454,373 ,300 ,235, 178 ,129, 88  , 55  ,30   ,13   ,14   ,15   ,16  ,17   ,38   ,67  ,104 ,149 ,202 ,263 ,332 ,409  ,494,
        453,372 ,299 ,234, 177 ,128, 87  , 54  ,29   ,12   ,3     ,4    ,5    ,18   ,39   ,68  ,105 ,150 ,203 ,264 ,333 ,410 , 495,
        452,371 ,298 ,233, 176 ,127, 86  , 53  ,28   ,11   ,2     ,1    ,6    ,19   ,40   ,69  ,106 ,151 ,204 ,265 ,334 ,411 , 496,
        451,370 ,297 ,232, 175 ,126, 85  , 52  ,27   ,10   ,9     ,8    ,7    ,20   ,41   ,70  ,107 ,152 ,205 ,266 ,335 ,412 , 497,
        450,369 ,296 ,231, 174 ,125, 84  , 51  ,26   ,25   ,24   ,23   ,22  ,21   ,42   ,71  ,108 ,153 ,206 ,267 ,336 ,413  ,498,
        449,368 ,295 ,230, 173 ,124, 83  , 50  ,49   ,48   ,47   ,46   ,45  ,44   ,43   ,72  ,109 ,154 ,207 ,268 ,337 ,414  ,499,
        448,367 ,294 ,229, 172 ,123, 82  , 81  ,80   ,79   ,78   ,77   ,76  ,75   ,74   ,73  ,110 ,155 ,208 ,269 ,338 ,415  ,500,
        447,366 ,293 ,228, 171 ,122, 121, 120 ,119, 118 ,117 ,116 ,115 ,114 ,113 ,112 ,111 ,156 ,209 ,270 ,339 ,416, 501,
        446,365 ,292 ,227, 170 ,169, 168, 167 ,166, 165 ,164 ,163 ,162 ,161 ,160 ,159 ,158 ,157 ,210 ,271 ,340 ,417, 502,
        445,364 ,291 ,226, 225 ,224, 223, 222 ,221, 220 ,219 ,218 ,217 ,216 ,215 ,214 ,213 ,212 ,211 ,272 ,341 ,418, 503,
        444,363 ,290 ,289, 288 ,287, 286, 285 ,284, 283 ,282 ,281 ,280 ,279 ,278 ,277 ,276 ,275 ,274 ,273 ,342 ,419, 504,
        443,362 ,361 ,360, 359 ,358, 357, 356 ,355, 354 ,353 ,352 ,351 ,350 ,349 ,348 ,347 ,346 ,345 ,344 ,343 ,420, 505,
        442,441 ,440 ,439, 438 ,437, 436, 435 ,434, 433 ,432 ,431 ,430 ,429 ,428 ,427 ,426 ,425 ,424 ,423 ,422 ,421, 506,
        529,528 ,527 ,526, 525 ,524, 523, 522 ,521, 520 ,519 ,518 ,517 ,516 ,515 ,514 ,513 ,512 ,511 ,510 ,509 ,508, 507
    };

	private int[] edgeList = new int[]{9,307, 241,183,133,91,57,31,13,3,5,17,37,65,101,145,197,257,325,7,21,43,73,111,157,211,273,343,25,49,81,121,169,225,289,361, 463, 381, 401, 485, 421, 507, 441, 529};
	private int[] crossList = new int[]{40,316, 249, 190, 139, 96, 61, 34, 15, 4, 6, 19, 69, 106, 151, 204, 265, 334, 8, 23, 46, 77, 116, 163, 218, 281, 352, 2, 11, 28, 53, 86, 127, 176, 233, 298, 431, 518, 411, 496, 371, 452, 391, 474};
	private List<int> edgeareaList = new List<int>();


	public enum NumberType
	{
		crossarea,
		edgearea,
		cross,
		edge
	}


	public GameObject gridObj;
	private List<GannCell> cellList = new List<GannCell> ();

	public InputField priceInput;
	public Dropdown dropdown;
	public Text confirmText;
	public Text changeText;
	public Text targetText;
	public Text stopText;

	private int marketPrice = 0;
	private int option = 0;
	void Awake(){

		foreach (int n in edgeList) {
			if (n > 7) {
				edgeareaList.Add (n - 1);
				edgeareaList.Add (n + 1);
			}
		}

		for (int i = 1; i <= numberList.Length; i++) {
			GannCell c = gridObj.transform.Find ("Cell (" + i + ")").GetComponent<GannCell>();
			cellList.Add (c);
			c.Initial ();
		}

		for (int i = 0; i < cellList.Count; i++) {

			NumberType targetType = NumberType.crossarea;

			foreach (int n in edgeList) {
				if (n == numberList [i]) {
					targetType = NumberType.edge;
					break;
				}
			}

			if (targetType == NumberType.crossarea) {
				foreach (int n in crossList) {
					if (n == numberList [i]) {
						targetType = NumberType.cross;
						break;
					}
				}
			}

			if (targetType == NumberType.crossarea) {
				foreach (int n in edgeareaList) {
					if (n == numberList [i]) {
						targetType = NumberType.edgearea;
						break;
					}
				}
			}

			cellList [i].SetValue (numberList [i], targetType);
		}

		cellList.Sort((p1,p2)=>p1.value.CompareTo(p2.value));
	}
		
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void InputPrice(string value)
	{
		marketPrice = int.Parse(priceInput.text);
		Calculate ();
	}

	public void DropDownChange(int d)
	{
		option = d;
		Calculate ();
	}

	private void Calculate()
	{
		foreach (GannCell c in cellList) {
			c.Reset();
		}

		int confirmPrice = 0;
		int changePrice = 0;
		int targetPrice = 0;
		int stopPrice = 0;

		int distanceA = 0;

		if (marketPrice <= 0 || marketPrice > 529)
			return;

        bool skipOne = false;
		if (option == 0) {
			for (int i = marketPrice - 1; i < cellList.Count; i++) {
				cellList [i].TriggerColor (Color.green, Color.black);
				if ((cellList [i].type == NumberType.cross || cellList [i].type == NumberType.edge)) {
                    if (i > marketPrice + 1)
                    {
                        confirmPrice = cellList[i].value;
                        confirmText.text = cellList[i].value.ToString();
                        if (cellList[i].type == NumberType.edge && Mathf.Sqrt(confirmPrice) == Mathf.Round(Mathf.Sqrt(confirmPrice)))
                            distanceA = confirmPrice - marketPrice + 1;
                        else
                            distanceA = confirmPrice - marketPrice;

                        break;
                    }
                    else
                        skipOne = true;

                }
			}

			for (int i = confirmPrice; i < cellList.Count; i++) {
				cellList [i].TriggerColor (Color.green, Color.black);
				if (cellList [i].type == NumberType.cross || cellList [i].type == NumberType.edge) {
					changePrice = cellList [i].value;
					changeText.text = cellList [i].value.ToString ();
					break;
				}
			}

			int count = 0;
			if (cellList [marketPrice - 1].type == NumberType.crossarea || cellList [marketPrice - 1].type == NumberType.cross) {
                if (cellList[confirmPrice - 1].type == NumberType.cross)
                {
                    if (skipOne)
                        count = 0;
                    else
                        count = 3;
                }
                else if (cellList[confirmPrice - 1].type == NumberType.edge)
                    count = 1;
                else
                    count = 1;

            } else {
				count = 1;
			}

            if (count > 0)
            {
                for (int i = changePrice; i < cellList.Count; i++)
                {
                    cellList[i].TriggerColor(Color.green, Color.black);
                    if (cellList[i].type == NumberType.cross || cellList[i].type == NumberType.edge)
                    {
                        count--;
                        if (count == 0)
                        {
                            for (int j = i; j <= i + distanceA; j++)
                            {
                                cellList[j].TriggerColor(Color.green, Color.black);
                            }

                            targetText.text = cellList[i + distanceA].value.ToString();
                            targetPrice = cellList[i + distanceA].value;
                            break;
                        }
                    }
                }
            }
            else
            {
                cellList[changePrice].TriggerColor(Color.green, Color.black);
                targetText.text = cellList[changePrice].value.ToString();
                targetPrice = cellList[changePrice].value;
                cellList[changePrice + 1].TriggerColor(Color.green, Color.black);
                targetText.text = cellList[changePrice + 1].value.ToString();
                targetPrice = cellList[changePrice + 1].value;
            }

			for (int i = marketPrice - 1; i > 0; i--) {
				cellList [i].TriggerColor (Color.red, Color.white);
				if ((cellList [i].type == NumberType.cross || cellList [i].type == NumberType.edge) && marketPrice - i > 3) {
					stopPrice = cellList [i].value;
					stopText.text = cellList [i].value.ToString ();
					break;
				}
			}
		} else {
			for (int i = marketPrice - 1;i > 0; i--) {
				cellList [i].TriggerColor (Color.green, Color.black);
				if ((cellList [i].type == NumberType.cross || cellList [i].type == NumberType.edge)) {
                    if (marketPrice - i > 3)
                    {
                        confirmPrice = cellList[i].value;
                        confirmText.text = cellList[i].value.ToString();
                        if (cellList[i].type == NumberType.edge && Mathf.Sqrt(confirmPrice) == Mathf.Round(Mathf.Sqrt(confirmPrice)))
                            distanceA = marketPrice - confirmPrice - 1;
                        else
                            distanceA = marketPrice - confirmPrice;

                        break;
                    }
                    else
                        skipOne = true;
				}
			}

			for (int i = confirmPrice - 2; i > 0; i--) {
				cellList [i].TriggerColor (Color.green, Color.black);
				if (cellList [i].type == NumberType.cross || cellList [i].type == NumberType.edge) {
					changePrice = cellList [i].value;
					changeText.text = cellList [i].value.ToString ();
					break;
				}
			}

			int count = 0;
			if (cellList [marketPrice - 1].type == NumberType.crossarea || cellList [marketPrice - 1].type == NumberType.cross) {
                if (cellList[confirmPrice - 1].type == NumberType.cross)
                {
                    if (skipOne)
                        count = 0;
                    else
                        count = 3;
                }
                else if (cellList[confirmPrice - 1].type == NumberType.edge)
                    count = 1;
			} else {
				count = 1;
			}

            if (count > 0)
            {
                for (int i = changePrice - 2; i > 0; i--)
                {
                    cellList[i].TriggerColor(Color.green, Color.black);
                    if (cellList[i].type == NumberType.cross || cellList[i].type == NumberType.edge)
                    {
                        count--;
                        if (count == 0)
                        {
                            for (int j = i; j >= i - distanceA; j--)
                            {
                                cellList[j].TriggerColor(Color.green, Color.black);
                            }

                            targetText.text = cellList[i - distanceA].value.ToString();
                            targetPrice = cellList[i - distanceA].value;
                            break;
                        }
                    }
                }
            }
            else
            {
                cellList[changePrice - 2].TriggerColor(Color.green, Color.black);
                targetText.text = cellList[changePrice - 2].value.ToString();
                targetPrice = cellList[changePrice - 2].value;
                cellList[changePrice - 3].TriggerColor(Color.green, Color.black);
                targetText.text = cellList[changePrice - 3].value.ToString();
                targetPrice = cellList[changePrice - 3].value;
            }
				
			for (int i = marketPrice; i < cellList.Count; i++) {
				cellList [i].TriggerColor (Color.red, Color.white);
				if ((cellList [i].type == NumberType.cross || cellList [i].type == NumberType.edge) && i > marketPrice + 1) {
					stopPrice = cellList [i].value;
					stopText.text = cellList [i].value.ToString ();
					break;
				}
			}
		}

		cellList [marketPrice - 1].TriggerColor (Color.blue, Color.white);
	}
}
