###tum isteklerde x-api-key headeri alttaki key'e sahip olmalidir
```
2WxnVNoQu2PI8oRc+JDNZPlFqUuCaLyWnQsXCOKpbmZl1i2+j3f36+Is3+3uMcCw8uzLpuDHQqS0A4ERWVmYA0/X7+crfFLWOmVys1Iris8=
```

###fightwarrior ve GetMyWarriorWithApiKey endpointinde warrior-API-Key headeri ilgili savascinin keyine sahip olmalidir
```json
"apikey": "Tv7G4uFR01qzaJlAFjufu2G/HEvskDTEmeIqUXNpGxOW4nVg3Wh11/zqoo14E41A3G0xy1Q2wJTdIkoMDCWmjfI=",
```

```js
POST /api/warriors/CreateWarrior 
```
string isim ve byte olarak can degeri bekliyor
```json
{
  "name" : "name",
  "health": 99 //byte
}
```

response olusturulan savascının bilgilerini doner

```json
{
  "warrior": {
    "apikey": "Tv7G4uFR01qzaJlAFjufu2G/HEvskDTEmeIqUXNpGxOW4nVg3Wh11/zqoo14E41A3G0xy1Q2wJTdIkoMDCWmjfI=",
    "name": "bertan",
    "health": 100,
    "attack": {
      "short": 16,
      "long": 8
    },
    "defance": {
      "short": 9,
      "long": 4
    },
    "fightDetails": [],
    "id": {
      "value": "77c0f3f2-660d-4a7b-9fad-58698f5c2cae"
    }
  }
}
```



/api/warriors/DeleteWarrior/{id}
    guid savascı id beklemektedir

```js
DELETE /api/warriors/deletewarrior/77c0f3f2-660d-4a7b-9fad-58698f5c2cae
```

response silinen savascının bilgilerini doner
```json
{
  "warrior": {
    "apikey": "Tv7G4uFR01qzaJlAFjufu2G/HEvskDTEmeIqUXNpGxOW4nVg3Wh11/zqoo14E41A3G0xy1Q2wJTdIkoMDCWmjfI=",
    "name": "bertan",
    "health": 100,
    "attack": {
      "short": 16,
      "long": 8
    },
    "defance": {
      "short": 9,
      "long": 4
    },
    "fightDetails": [],
    "id": {
      "value": "77c0f3f2-660d-4a7b-9fad-58698f5c2cae"
    }
  }
}
```
/api/warriors/GenerateRandomWarriors
    tek seferde en fazla 255 tane olmak uzere rastgele savasci olusturur

```js
GET /api/Warriors/GenerateRandomWarriors?times=15 
```

response olusturulan savascilari geriye doner
```json
[
  {
    "apikey": "fb0RZ2woy2sJkHYF+A2ejJjAwiJj+X04tuWHpYgqYEICB43yAD9duxKi9ti7jXw5y7YJpCMCmkT+4ceHBvbWu8Nkr/RlHyUS3tfOkTY8N6Gy7CEq+t/7ppRxIKKjEQ==",
    "name": "Savaşçı 032ce192-36b2-4bc7-9dbe-f1dc7da6769f",
    "health": 96,
    "attack": {
      "short": 15,
      "long": 10
    },
    "defance": {
      "short": 12,
      "long": 5
    },
    "fightDetails": [],
    "id": {
      "value": "6327d64f-21f6-4499-865c-434b2518aada"
    }
  }
]
```

/api/warriors/GetAllWarriors
    tum savascilarin verilerini response olarak doner
    savas detaylari ve savastaki raund detaylari dahildir


/api/warriors/GetMyWarriorWithApiKey
    eger api key mevcut ise gonderilen key savascilar arasinda 
    arayarak ilgili karakteri bulup geriye doner


/api/warriors/FightWarrior/{savasilacak karakter id'si}
    route ile gınderilen karakter id'sini rastgele olarak liste icinden
    eslestirip savasa baslatir

    geriye ilgili savasin detaylarini raund raund olacak sekilde doner
    bu islemde iki savasciya da veri girisi olmaktadır

```js
GET /api/Warriors/FightWarrior/77c0f3f2-660d-4a7b-9fad-58698f5c2cae
```

```json
{
  "fightDetail": {
    "matchedWarriorId": {
      "value": "bc67ea01-b424-455b-8d27-dd856dc9c421"
    },
    "startedWarriorId": {
      "value": "77c0f3f2-660d-4a7b-9fad-58698f5c2cae"
    },
    "startedTime": "2022-11-27T03:28:18.3903227+03:00",
    "finishedTime": "2022-11-27T03:28:18.3944981+03:00",
    "fightTime": "00:00:00.0041754",
    "rounds": [
      //raund 1
      {
        "roundStartedTime": "2022-11-27T03:28:18.390956+03:00",
        "roundCompletedTime": "2022-11-27T03:28:18.3914059+03:00",
        "roundTime": "00:00:00.0004499",
        "roundNumber": 1, //<--
        "attackedWarriorId": {
          "value": "77c0f3f2-660d-4a7b-9fad-58698f5c2cae"
        },
        "attackQuantity": 16,
        "warriorAttackType": 0,
        "attackerHealth": 100,
        "defancedWarriorId": {
          "value": "bc67ea01-b424-455b-8d27-dd856dc9c421"
        },
        "defanceQuantity": 9,
        "warriorDefanceType": 0,
        "defancerHealth": 81,
        "roundFinishedDefancerHealth": 74,
        "takenDamage": 7,
        "id": { // <-- raund id
          "value": "0db77cec-0149-459c-a9d5-59e64548b5eb"
        }
      },
      {
        "roundStartedTime": "2022-11-27T03:28:18.3942225+03:00",
        "roundCompletedTime": "2022-11-27T03:28:18.3942285+03:00",
        "roundTime": "00:00:00.0000060",
        "roundNumber": 2,
        "attackedWarriorId": {
          "value": "bc67ea01-b424-455b-8d27-dd856dc9c421"
        },
        "attackQuantity": 12,
        "warriorAttackType": 1,
        "attackerHealth": 74,
        "defancedWarriorId": {
          "value": "77c0f3f2-660d-4a7b-9fad-58698f5c2cae"
        },
        "defanceQuantity": 12,
        "warriorDefanceType": 0,
        "defancerHealth": 100,
        "roundFinishedDefancerHealth": 88,
        "takenDamage": 12,
        "id": {
          "value": "1ddccd2e-8190-4663-91c0-f856c0bf546b"
        }
      },
      {
        "roundStartedTime": "2022-11-27T03:28:18.394241+03:00",
        "roundCompletedTime": "2022-11-27T03:28:18.394256+03:00",
        "roundTime": "00:00:00.0000150",
        "roundNumber": 3,
        "attackedWarriorId": {
          "value": "77c0f3f2-660d-4a7b-9fad-58698f5c2cae"
        },
        "attackQuantity": 16,
        "warriorAttackType": 0,
        "attackerHealth": 88,
        "defancedWarriorId": {
          "value": "bc67ea01-b424-455b-8d27-dd856dc9c421"
        },
        "defanceQuantity": 4,
        "warriorDefanceType": 1,
        "defancerHealth": 74,
        "roundFinishedDefancerHealth": 58,
        "takenDamage": 16,
        "id": {
          "value": "a9a901cd-b3c8-46c4-8194-becfea1ceb94"
        }
      },
      {
        "roundStartedTime": "2022-11-27T03:28:18.3942584+03:00",
        "roundCompletedTime": "2022-11-27T03:28:18.394259+03:00",
        "roundTime": "00:00:00.0000006",
        "roundNumber": 4,
        "attackedWarriorId": {
          "value": "bc67ea01-b424-455b-8d27-dd856dc9c421"
        },
        "attackQuantity": 15,
        "warriorAttackType": 0,
        "attackerHealth": 58,
        "defancedWarriorId": {
          "value": "77c0f3f2-660d-4a7b-9fad-58698f5c2cae"
        },
        "defanceQuantity": 12,
        "warriorDefanceType": 0,
        "defancerHealth": 88,
        "roundFinishedDefancerHealth": 85,
        "takenDamage": 3,
        "id": {
          "value": "aa3c3285-0520-4e5b-aefa-8300ba9a1f10"
        }
      },
      {
        "roundStartedTime": "2022-11-27T03:28:18.3942964+03:00",
        "roundCompletedTime": "2022-11-27T03:28:18.3942979+03:00",
        "roundTime": "00:00:00.0000015",
        "roundNumber": 5,
        "attackedWarriorId": {
          "value": "77c0f3f2-660d-4a7b-9fad-58698f5c2cae"
        },
        "attackQuantity": 9,
        "warriorAttackType": 1,
        "attackerHealth": 85,
        "defancedWarriorId": {
          "value": "bc67ea01-b424-455b-8d27-dd856dc9c421"
        },
        "defanceQuantity": 9,
        "warriorDefanceType": 0,
        "defancerHealth": 58,
        "roundFinishedDefancerHealth": 49,
        "takenDamage": 9,
        "id": {
          "value": "d5d9eb48-71cc-419b-b8ab-e06c2e51aaad"
        }
      },
      {
        "roundStartedTime": "2022-11-27T03:28:18.3943006+03:00",
        "roundCompletedTime": "2022-11-27T03:28:18.3943011+03:00",
        "roundTime": "00:00:00.0000005",
        "roundNumber": 6,
        "attackedWarriorId": {
          "value": "bc67ea01-b424-455b-8d27-dd856dc9c421"
        },
        "attackQuantity": 12,
        "warriorAttackType": 1,
        "attackerHealth": 49,
        "defancedWarriorId": {
          "value": "77c0f3f2-660d-4a7b-9fad-58698f5c2cae"
        },
        "defanceQuantity": 12,
        "warriorDefanceType": 0,
        "defancerHealth": 85,
        "roundFinishedDefancerHealth": 73,
        "takenDamage": 12,
        "id": {
          "value": "8fd23f2d-ba85-42a6-a69e-1728b576e83e"
        }
      },
      {
        "roundStartedTime": "2022-11-27T03:28:18.3943027+03:00",
        "roundCompletedTime": "2022-11-27T03:28:18.3943033+03:00",
        "roundTime": "00:00:00.0000006",
        "roundNumber": 7,
        "attackedWarriorId": {
          "value": "77c0f3f2-660d-4a7b-9fad-58698f5c2cae"
        },
        "attackQuantity": 9,
        "warriorAttackType": 1,
        "attackerHealth": 73,
        "defancedWarriorId": {
          "value": "bc67ea01-b424-455b-8d27-dd856dc9c421"
        },
        "defanceQuantity": 9,
        "warriorDefanceType": 0,
        "defancerHealth": 49,
        "roundFinishedDefancerHealth": 40,
        "takenDamage": 9,
        "id": {
          "value": "9d01e060-2998-4f95-bd41-4b0817106df2"
        }
      },
      {
        "roundStartedTime": "2022-11-27T03:28:18.394305+03:00",
        "roundCompletedTime": "2022-11-27T03:28:18.3943058+03:00",
        "roundTime": "00:00:00.0000008",
        "roundNumber": 8,
        "attackedWarriorId": {
          "value": "bc67ea01-b424-455b-8d27-dd856dc9c421"
        },
        "attackQuantity": 15,
        "warriorAttackType": 0,
        "attackerHealth": 40,
        "defancedWarriorId": {
          "value": "77c0f3f2-660d-4a7b-9fad-58698f5c2cae"
        },
        "defanceQuantity": 4,
        "warriorDefanceType": 1,
        "defancerHealth": 73,
        "roundFinishedDefancerHealth": 58,
        "takenDamage": 15,
        "id": {
          "value": "d6b11c82-d1be-4c5c-8aa1-5f443011ec76"
        }
      },
      {
        "roundStartedTime": "2022-11-27T03:28:18.3943304+03:00",
        "roundCompletedTime": "2022-11-27T03:28:18.394331+03:00",
        "roundTime": "00:00:00.0000006",
        "roundNumber": 9,
        "attackedWarriorId": {
          "value": "77c0f3f2-660d-4a7b-9fad-58698f5c2cae"
        },
        "attackQuantity": 9,
        "warriorAttackType": 1,
        "attackerHealth": 58,
        "defancedWarriorId": {
          "value": "bc67ea01-b424-455b-8d27-dd856dc9c421"
        },
        "defanceQuantity": 9,
        "warriorDefanceType": 0,
        "defancerHealth": 40,
        "roundFinishedDefancerHealth": 31,
        "takenDamage": 9,
        "id": {
          "value": "6a31d524-d198-4132-a459-8fc04f77b688"
        }
      },
      {
        "roundStartedTime": "2022-11-27T03:28:18.3943331+03:00",
        "roundCompletedTime": "2022-11-27T03:28:18.3943335+03:00",
        "roundTime": "00:00:00.0000004",
        "roundNumber": 10,
        "attackedWarriorId": {
          "value": "bc67ea01-b424-455b-8d27-dd856dc9c421"
        },
        "attackQuantity": 15,
        "warriorAttackType": 0,
        "attackerHealth": 31,
        "defancedWarriorId": {
          "value": "77c0f3f2-660d-4a7b-9fad-58698f5c2cae"
        },
        "defanceQuantity": 12,
        "warriorDefanceType": 0,
        "defancerHealth": 58,
        "roundFinishedDefancerHealth": 55,
        "takenDamage": 3,
        "id": {
          "value": "1d7ed3c5-872b-4e8f-a5b9-b50172ee0ab7"
        }
      },
      {
        "roundStartedTime": "2022-11-27T03:28:18.3943355+03:00",
        "roundCompletedTime": "2022-11-27T03:28:18.3943359+03:00",
        "roundTime": "00:00:00.0000004",
        "roundNumber": 11,
        "attackedWarriorId": {
          "value": "77c0f3f2-660d-4a7b-9fad-58698f5c2cae"
        },
        "attackQuantity": 16,
        "warriorAttackType": 0,
        "attackerHealth": 55,
        "defancedWarriorId": {
          "value": "bc67ea01-b424-455b-8d27-dd856dc9c421"
        },
        "defanceQuantity": 4,
        "warriorDefanceType": 1,
        "defancerHealth": 31,
        "roundFinishedDefancerHealth": 15,
        "takenDamage": 16,
        "id": {
          "value": "4fb25213-af5f-4e2b-bd79-05ece958efaf"
        }
      },
      {
        "roundStartedTime": "2022-11-27T03:28:18.3943375+03:00",
        "roundCompletedTime": "2022-11-27T03:28:18.3943379+03:00",
        "roundTime": "00:00:00.0000004",
        "roundNumber": 12,
        "attackedWarriorId": {
          "value": "bc67ea01-b424-455b-8d27-dd856dc9c421"
        },
        "attackQuantity": 12,
        "warriorAttackType": 1,
        "attackerHealth": 15,
        "defancedWarriorId": {
          "value": "77c0f3f2-660d-4a7b-9fad-58698f5c2cae"
        },
        "defanceQuantity": 4,
        "warriorDefanceType": 1,
        "defancerHealth": 55,
        "roundFinishedDefancerHealth": 47,
        "takenDamage": 8,
        "id": {
          "value": "8229c481-1218-4df0-8cdb-12027bed3c6c"
        }
      },
      {
        "roundStartedTime": "2022-11-27T03:28:18.3943395+03:00",
        "roundCompletedTime": "2022-11-27T03:28:18.3943402+03:00",
        "roundTime": "00:00:00.0000007",
        "roundNumber": 13,
        "attackedWarriorId": {
          "value": "77c0f3f2-660d-4a7b-9fad-58698f5c2cae"
        },
        "attackQuantity": 16,
        "warriorAttackType": 0,
        "attackerHealth": 47,
        "defancedWarriorId": {
          "value": "bc67ea01-b424-455b-8d27-dd856dc9c421"
        },
        "defanceQuantity": 4,
        "warriorDefanceType": 1,
        "defancerHealth": 15,
        "roundFinishedDefancerHealth": -1,
        "takenDamage": 16,
        "id": { 
          "value": "762ae966-5154-4ab0-a51a-58aeb9687ebe"
        }
      }
    ],
    "totalRounds": 13, //<--
    "winnerWarrior": {
      "value": "77c0f3f2-660d-4a7b-9fad-58698f5c2cae"
    },
    "id": { //<-- fight id
      "value": "8eee7ca1-e370-465c-ba67-621ff83c2a76"
    }
  }
}
```