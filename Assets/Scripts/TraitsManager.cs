using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraitsManager : MonoBehaviour {
    public struct Trait {
        private string name;

        private int happiness_delta_min;
        private int happiness_delta_max;

        private int population_delta_min;
        private int population_delta_max;

        private int economy_delta_min;
        private int economy_delta_max;

        private int military_delta_min;
        private int military_delta_max;

        public Trait(string name, 
            int h_min, int h_max, 
            int p_min, int p_max, 
            int e_min, int e_max, 
            int m_min, int m_max) {

            this.name = name;

            this.happiness_delta_min = h_min;
            this.happiness_delta_max = h_max;

            this.population_delta_min = p_min;
            this.population_delta_max = p_max;

            this.economy_delta_min = e_min;
            this.economy_delta_max = e_max;

            this.military_delta_min = m_min;
            this.military_delta_max = m_max;
        }

        public string Name {
            get { return name; }
            set { name = value; }
        }

        public int HappinessDeltaMin {
            get { return happiness_delta_min; }
            set { happiness_delta_min =  value; }
        }
        public int HappinessDeltaMax {
            get { return happiness_delta_max; }
            set { happiness_delta_max = value; }
        }

        public int PopulationDeltaMin {
            get { return population_delta_min; }
            set { population_delta_min = value; }
        }
        public int PopulationDeltaMax {
            get { return population_delta_max; }
            set { population_delta_max = value; }
        }

        public int EconomyDeltaMin {
            get { return economy_delta_min; }
            set { economy_delta_min = value; }
        }

        public int EconomyDeltaMax {
            get { return economy_delta_max; }
            set { economy_delta_max = value; }
        }

        public int MilitaryDeltaMin {
            get { return military_delta_min; }
            set { military_delta_min = value; }
        }

        public int MilitaryDeltaMax {
            get { return military_delta_max; }
            set { military_delta_max = value; }
        }

    }

    List<Trait> traits = new List<Trait>();
    List<string> names = new List<string> 
    { 
        "Billy", "Matthew", "Ivy", "Kevin", 
        "Kendall", "Roman", "Shiv", "Connor",
    };

    public static TraitsManager instance;

    private void Awake() {
        if (instance != null && instance != this) {
            Destroy(this);
        }
        else {
            instance = this;
        }
    }

    public void Start() {
        traits.Clear();
        traits.Add(new Trait(
            "Aggressive",
            -5, 0,
            -5, 0,
            -5, 5,
            10, 15));
        traits.Add(new Trait(
            "Frugal",
            -5, 0,
            0, 0,
            5, 10,
            0, 0));
    }

    public Trait GetRandomTrait() {
        return traits[Random.Range(0, traits.Count)];
    }

    public string GetRandomName() {
        return names[Random.Range(0, names.Count)];
    }
}
